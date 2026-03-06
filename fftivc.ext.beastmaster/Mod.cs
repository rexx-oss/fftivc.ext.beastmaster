using fftivc.ext.beastmaster.Configuration;
using fftivc.ext.beastmaster.Template;
using Microsoft.Extensions.DependencyInjection;
using Reloaded.Hooks.Definitions;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using System;

#if DEBUG
using System.Diagnostics;
#endif

namespace fftivc.ext.beastmaster
{
    /// <summary>
    /// Your mod logic goes here.
    /// </summary>
    public class Mod : ModBase
    {
        private static IStartupScanner _startupScanner = null;

        /// <summary>
        /// Provides access to the mod loader API.
        /// </summary>
        private readonly IModLoader _modLoader;

        /// <summary>
        /// Provides access to the Reloaded logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Entry point into the mod, instance that created this class.
        /// </summary>
        private readonly IMod _owner;

        /// <summary>
        /// Provides access to this mod's configuration.
        /// </summary>
        private Config _configuration;

        /// <summary>
        /// The configuration of the currently executing mod.
        /// </summary>
        private readonly IModConfig _modConfig;

        /// <summary>
        /// Provides access to the Reloaded.Hooks API.
        /// </summary>
        /// <remarks>This is null if you remove dependency on Reloaded.SharedLib.Hooks in your mod.</remarks>
        private readonly IReloadedHooks _hooks;

        private readonly IServiceProvider _services;
        private readonly BeastmasterController _beastmasterController;

        public Mod(ModContext context)
        {
            _modLoader = context.ModLoader;
            _logger = context.Logger;
            _owner = context.Owner;
            _configuration = context.Configuration;
            _hooks = context.Hooks;
            _modConfig = context.ModConfig;

#if DEBUG
            // Attaches debugger in debug mode; ignored in release.
            Debugger.Launch();
#endif

            var startupScannerController = _modLoader.GetController<IStartupScanner>();
            if (startupScannerController == null || !startupScannerController.TryGetTarget(out _startupScanner))
            {
                _logger.WriteLine($"[{_modConfig.ModId}] Could not fetch IStartupScanner", _logger.ColorRed);
                return;
            }

            _services = BuildServiceCollection();

            _beastmasterController = _services.GetService<BeastmasterController>();
            _beastmasterController.Init();

            RegisterR2Controllers();

            _modLoader.OnModLoaderInitialized += OnAllModsLoaded;
        }

        public override void ConfigurationUpdated(Config configuration)
        {
            _configuration = configuration;

            _beastmasterController.Update(_configuration);

            _logger.WriteLine($"[{_modConfig.ModId}] Config Updated - Changes Applied");
        }

        private void OnAllModsLoaded()
        {
            _beastmasterController.Install();
        }

        private void RegisterR2Controllers()
        {
            
        }

        private IServiceProvider BuildServiceCollection()
        {
            var services = new ServiceCollection();

            services
                .AddSingleton(_modConfig)
                .AddSingleton(_modLoader)
                .AddSingleton(_startupScanner!)
                .AddSingleton(_configuration)
                .AddSingleton(_hooks)
                .AddSingleton(_logger);

            services.AddSingleton<BeastmasterController>();

            return services.BuildServiceProvider();
        }

        #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Mod() { }
#pragma warning restore CS8618
        #endregion
    }
}