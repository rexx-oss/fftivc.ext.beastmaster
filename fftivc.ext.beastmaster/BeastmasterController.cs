using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using fftivc.ext.beastmaster.Configuration;
using fftivc.ext.beastmaster.Data;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using Reloaded.Memory;
using Reloaded.Memory.Enums;
using Reloaded.Memory.Interfaces;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;

namespace fftivc.ext.beastmaster
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct HEIGHT_DATA
    {
        public byte UnitX;
        public byte UnitY;
        public byte UnitElevation;
        public byte UnitId;
        public byte UnitHeight;
        public byte WalkingHeight;
        public byte TotalHeight;
        public byte __Pad;
    }

    public class BeastmasterController
    {
        private const int BattleUnitSize = 0x200;
        private const int BattleUnitCount = 21;
        private const int BattleUnitLoadOffset = 84;
        private const int BattleUnitMapLocXOffset = 0x04F;
        private const int UnitIdOffset = 0x1BC;
        private const byte MonsterUnitType = 0x82;
        private const byte EntdTeamBits = 0x30;

        [Function(CallingConventions.Fastcall)]
        private unsafe delegate int MonsterSkillCheckPrepDelegate(BATTLE_UNIT_DATA* pUnit);

        [Function(CallingConventions.Fastcall)]
        private unsafe delegate int MonsterSkillCheckDelegate(byte entdFlags, int mapX, int mapY, byte height);

        [Function(CallingConventions.Fastcall)]
        private unsafe delegate HEIGHT_DATA* CalculateHeightDataDelegate(HEIGHT_DATA* pData, uint unitId);

        private static IHook<MonsterSkillCheckPrepDelegate> MonsterSkillCheckPrepHook;
        private static MonsterSkillCheckDelegate MonsterSkillCheck;
        private static CalculateHeightDataDelegate CalculateHeightData;

        private readonly IStartupScanner _startupScanner;
        private readonly IModConfig _modConfig;
        private readonly IReloadedHooks _hooks;
        private readonly ILogger _logger;

        private Config _config;
        private nint _processAddress;
        private nuint _monsterSkillCheckPrepFnAddress;
        private nuint _monsterSkillCheckFnAddress;
        private nuint _calculateHeightDataFnAddress;
        private nuint _battleUnitDataAddress;

        public BeastmasterController(IStartupScanner startupScanner,
            IModConfig modConfig,
            IReloadedHooks hooks,
            Config config,
            ILogger logger)
        {
            _startupScanner = startupScanner;
            _modConfig = modConfig;
            _hooks = hooks;
            _config = config;
            _logger = logger;
        }

        public void Init()
        {
            _processAddress = Process.GetCurrentProcess()!.MainModule!.BaseAddress;

            _startupScanner!.AddMainModuleScan(
                "48 89 5C 24 10 48 89 6C 24 18 56 57 41 56 48 83 EC 20 80 79 01 FF", e =>
                {
                    if (!e.Found)
                    {
                        _logger.WriteLine($"[{_modConfig.ModId}] - Failed to locate MonsterSkillCheckPrep function", _logger.ColorRed);
                        return;
                    }

                    _monsterSkillCheckPrepFnAddress = (nuint)(_processAddress + e.Offset);

                    _logger.WriteLine($"[{_modConfig.ModId}] Located the MonsterSkillCheckPrep function @ 0x{_monsterSkillCheckPrepFnAddress:X}");
                });

            _startupScanner!.AddMainModuleScan(
                "48 8B C4 48 89 58 08 48 89 68 10 48 89 70 18 48 89 78 20 41 56 48 83 EC 30 45 0F B6 F1", e =>
                {
                    if (!e.Found)
                    {
                        _logger.WriteLine($"[{_modConfig.ModId}] - Failed to locate MonsterSkillCheck function", _logger.ColorRed);
                        return;
                    }

                    _monsterSkillCheckFnAddress = (nuint)(_processAddress + e.Offset);

                    _logger.WriteLine($"[{_modConfig.ModId}] Located the MonsterSkillCheck function @ 0x{_monsterSkillCheckFnAddress:X}");
                });

            _startupScanner!.AddMainModuleScan(
                "48 89 E0 48 89 58 08 48 89 68 10 48 89 70 18 48 89 78 20 41 56 41 57 31 C0", e =>
                {
                    if (!e.Found)
                    {
                        _logger.WriteLine($"[{_modConfig.ModId}] - Failed to locate CalculateHeightData function", _logger.ColorRed);
                        return;
                    }

                    _calculateHeightDataFnAddress = (nuint)(_processAddress + e.Offset);

                    _logger.WriteLine($"[{_modConfig.ModId}] Located the CalculateHeightData function @ 0x{_calculateHeightDataFnAddress:X}");
                });
        }

        public unsafe void Install()
        {
            if (_monsterSkillCheckPrepFnAddress == default ||
                _monsterSkillCheckFnAddress == default ||
                _calculateHeightDataFnAddress == default)
                return;

            var loadAddress = _monsterSkillCheckFnAddress + BattleUnitLoadOffset;

            using (Memory.Instance.ChangeProtectionDisposable(loadAddress, sizeof(int), MemoryProtection.Read))
            {
                var battleUnitOffset = Memory.Instance.Read<int>(loadAddress);
                _battleUnitDataAddress = (nuint)((nint)loadAddress + sizeof(int) + battleUnitOffset - BattleUnitMapLocXOffset);
            }

            Memory.Instance.ChangeProtection(_battleUnitDataAddress, BattleUnitSize * BattleUnitCount, MemoryProtection.ReadWriteExecute);

            MonsterSkillCheckPrepHook = _hooks
                .CreateHook<MonsterSkillCheckPrepDelegate>(MonsterSkillCheckPrepImpl, (long)_monsterSkillCheckPrepFnAddress)
                .Activate();

            MonsterSkillCheck = _hooks
                .CreateWrapper<MonsterSkillCheckDelegate>((long)_monsterSkillCheckFnAddress, out var _);

            CalculateHeightData = _hooks
                .CreateWrapper<CalculateHeightDataDelegate>((long)_calculateHeightDataFnAddress, out var _);
        }

        public void Update(Config configuration)
        {
            _config = configuration;
        }

        private unsafe int MonsterSkillCheckPrepImpl(BATTLE_UNIT_DATA* pUnit)
        {
            var pFirstBattleUnit = (byte*)_battleUnitDataAddress;
            var pOnePastLastBattleUnit = pFirstBattleUnit + BattleUnitSize * BattleUnitCount;

            if (pUnit < pFirstBattleUnit || pUnit > pOnePastLastBattleUnit || pUnit->UnitIndex == 0xFF)
                return 0;

            if (_config.SkipBeastmasterCheck)
                return 1;

            if (_config.InfiniteBeastmasterRange)
            {
                for (var i = 0; i < BattleUnitCount; ++i)
                {
                    BATTLE_UNIT_DATA* pCheckUnit = (BATTLE_UNIT_DATA*)(pFirstBattleUnit + BattleUnitSize * i);

                    if (pCheckUnit != pUnit &&
                        pCheckUnit->UnitIndex != 0xFF &&
                        pCheckUnit->UnitType != MonsterUnitType &&
                        pCheckUnit->SupportAbilities4.HasFlag(Data.Flags.SupportAbilityFlags4.Beastmaster) &&
                        (byte)((pUnit->EntdFlags ^ pCheckUnit->EntdFlags) & EntdTeamBits) == 0)
                        return 1;

                    pCheckUnit += BattleUnitSize;
                }

                return 0;
            }

            HEIGHT_DATA data;

            var range = Math.Max(1, Math.Min(8, _config.BeastmasterRange));

            var pHeightData = CalculateHeightData(&data, *(byte*)(pUnit + UnitIdOffset));

            for (var y = -range; y < range; ++y)
            {
                for (var x = -range; x < range; ++x)
                {
                    if ((x == 0 && y == 0) || (Math.Abs(x) + Math.Abs(y) > range))
                        continue;

                    if (MonsterSkillCheck(
                        pUnit->EntdFlags,
                        pUnit->MapX + x,
                        pUnit->MapY + y,
                        pHeightData->TotalHeight) > 0)
                        return 1;
                }
            }

            return 0;
        }
    }
}
