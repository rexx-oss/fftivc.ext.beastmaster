using System.Runtime.InteropServices;
using fftivc.ext.beastmaster.Data.Flags;
using fftivc.utility.modloader.Interfaces.Tables.Structures;

namespace fftivc.ext.beastmaster.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct BATTLE_UNIT_DATA
    {
        public byte UnitType;                                       // 0x000/0
        public byte UnitIndex;                                      // 0x001/1
        public byte SpriteId;                                       // 0x002/2  ???
        public byte JobId;                                          // 0x003/3
        public byte Unknown4;
        public byte EntdFlags;
        public byte Unknown6;
        public byte Unknown7;
        public byte Unknown8;
        public byte Unknown9;
        public ushort InnateAbility1Id;                             // 0x00A/10
        public ushort InnateAbility2Id;                             // 0x00C/12
        public ushort InnateAbility3Id;                             // 0x00E/14
        public ushort InnateAbility4Id;                             // 0x010/16
        public byte PrimaryJobSetId;                                // 0x012/18
        public byte SecondaryJobSetId;                              // 0x013/19
        public ushort ReactionAbilityId;                            // 0x014/20
        public ushort SupportAbilityId;                             // 0x016/22
        public ushort MovementAbilityId;                            // 0x018/24
        public ushort HeadEquipId;                                  // 0x01A/26
        public ushort BodyEquipId;                                  // 0x01C/28
        public ushort AccessoryId;                                  // 0x01E/30
        public ushort RightHandWeaponId;                            // 0x020/32
        public ushort RightHandShieldId;                            // 0x022/34
        public ushort LeftHandWeaponId;                             // 0x024/36
        public ushort LeftHandShieldId;                             // 0x026/38
        public byte Exp;                                            // 0x028/40
        public byte Level;                                          // 0x029/41
        public byte OriginalBrave;                                  // 0x02A/42
        public byte Brave;                                          // 0x02B/43
        public byte OriginalFaith;                                  // 0x02C/44
        public byte Faith;                                          // 0x02D/45
        public ushort Unknown46;                                    // 0x02E/46
        public ushort CurrentHP;                                    // 0x030/48
        public ushort MaxHP;                                        // 0x032/50
        public ushort CurrentMP;                                    // 0x034/52
        public ushort MaxMP;                                        // 0x036/54
        public byte BasePA;                                         // 0x038/56
        public byte BaseMA;                                         // 0x039/57
        public byte BaseSpeed;                                      // 0x03A/58
        public byte PAEquipBonus;                                   // 0x03B/59
        public byte MAEquipBonus;                                   // 0x03C/60
        public byte SpeedEquipBonus;                                // 0x03D/61
        public byte CurrentPA;                                      // 0x03E/62
        public byte CurrentMA;                                      // 0x03F/63
        public byte CurrentSpeed;                                   // 0x040/64
        public byte Unknown65;                                      // 0x041/65 
        public byte CurrentMove;                                    // 0x042/66
        public byte CurrentJump;                                    // 0x043/67
        public byte RightHandWP;                                    // 0x044/68 - Display
        public byte LeftHandWP;                                     // 0x045/69 - Display
        public byte RightHandWeaponEvasion;                         // 0x046/70 - Display
        public byte LeftHandWeaponEvasion;                          // 0x047/71 - Display
        public byte AccessoryPhysicalEvasion;                       // 0x048/72
        public byte LeftHandShieldPhysicalEvasion;                  // 0x049/73
        public byte RightHandShieldPhysicalEvasion;                 // 0x04A/74
        public byte ClassPhysicalEvasion;                           // 0x04B/75
        public byte AccessoryMagicalEvasion;                        // 0x04C/76
        public byte LeftHandShieldMagicalEvasion;                   // 0x04D/77
        public byte RightHandShieldMagicalEvasion;                  // 0x04E/78
        public byte MapX;                                           // 0x04F/79
        public byte MapY;                                           // 0x050/80
        public byte ElevationFacingDirection;                       // 0x051/81
        public JobEquippableItems1Flags EquippableItems1;           // 0x052/82
        public JobEquippableItems2Flags EquippableItems2;           // 0x053/83
        public JobEquippableItems3Flags EquippableItems3;           // 0x054/84
        public JobEquippableItems4Flags EquippableItems4;           // 0x055/85
        public JobEquippableItems5Flags EquippableItems5;           // 0x056/86
        public JobInnateStartImmuneStatus1Flags InnateStatus1;      // 0x057/87
        public JobInnateStartImmuneStatus2Flags InnateStatus2;      // 0x058/88
        public JobInnateStartImmuneStatus3Flags InnateStatus3;      // 0x059/89
        public JobInnateStartImmuneStatus4Flags InnateStatus4;      // 0x05A/90
        public JobInnateStartImmuneStatus5Flags InnateStatus5;      // 0x05B/91
        public JobInnateStartImmuneStatus1Flags ImmuneStatus1;      // 0x05C/92
        public JobInnateStartImmuneStatus2Flags ImmuneStatus2;      // 0x05D/93
        public JobInnateStartImmuneStatus3Flags ImmuneStatus3;      // 0x05E/94
        public JobInnateStartImmuneStatus4Flags ImmuneStatus4;      // 0x05F/95
        public JobInnateStartImmuneStatus5Flags ImmuneStatus5;      // 0x060/96
        public JobInnateStartImmuneStatus1Flags CurrentStatus1;     // 0x061/97
        public JobInnateStartImmuneStatus2Flags CurrentStatus2;     // 0x062/98
        public JobInnateStartImmuneStatus3Flags CurrentStatus3;     // 0x063/99
        public JobInnateStartImmuneStatus4Flags CurrentStatus4;     // 0x064/100
        public JobInnateStartImmuneStatus5Flags CurrentStatus5;     // 0x065/101
        public byte PoisonCT;                                       // 0x066/102
        public byte RegenCT;                                        // 0x067/103
        public byte ProtectCT;                                      // 0x068/104
        public byte ShellCT;                                        // 0x069/105
        public byte HasteCT;                                        // 0x06A/106
        public byte SlowCT;                                         // 0x06B/107
        public byte StopCT;                                         // 0x06C/108
        public byte WallCT;                                         // 0x06D/109
        public byte FaithCT;                                        // 0x06E/110
        public byte InnocentCT;                                     // 0x06F/111
        public byte CharmCT;                                        // 0x070/112
        public byte SleepCT;                                        // 0x071/113
        public byte ImmobilizeCT;                                   // 0x072/114
        public byte DisableCT;                                      // 0x073/115
        public byte ReflectCT;                                      // 0x074/116
        public byte DoomCT;                                         // 0x075/117
        public JobElementFlags AbsorbElements;                      // 0x076/118
        public JobElementFlags CancelElements;                      // 0x077/119
        public JobElementFlags HalfElements;                        // 0x078/120
        public JobElementFlags WeakElements;                        // 0x079/121
        public JobElementFlags StrongElements;                      // 0x07A/122
        public RAW_STAT RawHP;                                      // 0x07B/123
        public RAW_STAT RawMP;                                      // 0x07E/126
        public RAW_STAT RawSpeed;                                   // 0x081/129
        public RAW_STAT RawPA;                                      // 0x084/132
        public RAW_STAT RawMA;                                      // 0x087/135
        public byte HPGrowth;                                       // 0x08A/138
        public byte HPMultiplier;                                   // 0x08B/139
        public byte MPGrowth;                                       // 0x08C/140
        public byte MPMultiplier;                                   // 0x08D/141
        public byte SpeedGrowth;                                    // 0x08E/142
        public byte SpeedMultiplier;                                // 0x08F/143
        public byte PAGrowth;                                       // 0x090/144
        public byte PAMultiplier;                                   // 0x091/145
        public byte MAGrowth;                                       // 0x092/146
        public byte MAMultiplier;                                   // 0x093/147
        public ReactionAbilityFlags1 ReactionAbilities1;            // 0x094/148
        public ReactionAbilityFlags2 ReactionAbilities2;            // 0x095/149
        public ReactionAbilityFlags3 ReactionAbilities3;            // 0x096/150
        public ReactionAbilityFlags4 ReactionAbilities4;            // 0x097/151
        public SupportAbilityFlags1 SupportAbilities1;              // 0x098/152
        public SupportAbilityFlags2 SupportAbilities2;              // 0x099/153
        public SupportAbilityFlags3 SupportAbilities3;              // 0x09A/154
        public SupportAbilityFlags4 SupportAbilities4;              // 0x09B/155
        public MovementAbilityFlags1 MovementAbilities1;            // 0x09C/156
        public MovementAbilityFlags2 MovementAbilities2;            // 0x09D/157
        public MovementAbilityFlags3 MovementAbilities3;            // 0x09E/158
        public JobFlags1 UnlockedJobs1;                             // 0x09F/159
        public JobFlags2 UnlockedJobs2;                             // 0x0A0/160
        public JobFlags3 UnlockedJobs3;                             // 0x0A1/161
        public LEARNED_ABILITIES LearnedAbilities1;                 // 0x0A2/162
        public LEARNED_ABILITIES LearnedAbilities2;                 // 0x0A5/165
        public LEARNED_ABILITIES LearnedAbilities3;                 // 0x0A8/168
        public LEARNED_ABILITIES LearnedAbilities4;                 // 0x0AB/171
        public LEARNED_ABILITIES LearnedAbilities5;                 // 0x0AE/174
        public LEARNED_ABILITIES LearnedAbilities6;                 // 0x0B1/177
        public LEARNED_ABILITIES LearnedAbilities7;                 // 0x0B4/180
        public LEARNED_ABILITIES LearnedAbilities8;                 // 0x0B7/183
        public LEARNED_ABILITIES LearnedAbilities9;                 // 0x0BA/186
        public LEARNED_ABILITIES LearnedAbilities10;                // 0x0BD/189
        public LEARNED_ABILITIES LearnedAbilities11;                // 0x0C0/192
        public LEARNED_ABILITIES LearnedAbilities12;                // 0x0C3/195
        public LEARNED_ABILITIES LearnedAbilities13;                // 0x0C6/198
        public LEARNED_ABILITIES LearnedAbilities14;                // 0x0C9/201
        public LEARNED_ABILITIES LearnedAbilities15;                // 0x0CC/204
        public LEARNED_ABILITIES LearnedAbilities16;                // 0x0CF/207
        public LEARNED_ABILITIES LearnedAbilities17;                // 0x0D2/210
        public LEARNED_ABILITIES LearnedAbilities18;                // 0x0D5/213
        public LEARNED_ABILITIES LearnedAbilities19;                // 0x0D8/216
        public LEARNED_ABILITIES LearnedAbilities20;                // 0x0DB/219
        public LEARNED_ABILITIES LearnedAbilities21;                // 0x0DE/222
        public LEARNED_ABILITIES LearnedAbilities22;                // 0x0E1/225
        public byte JobLevels1_2;                                   // 0x0E4/228
        public byte JobLevels3_4;                                   // 0x0E5/229
        public byte JobLevels5_6;                                   // 0x0E6/230
        public byte JobLevels7_8;                                   // 0x0E7/231
        public byte JobLevels9_10;                                  // 0x0E8/232
        public byte JobLevels11_12;                                 // 0x0E9/233
        public byte JobLevels13_14;                                 // 0x0EA/234
        public byte JobLevels15_16;                                 // 0x0EB/235
        public byte JobLevels17_18;                                 // 0x0EC/236
        public byte JobLevels19_20;                                 // 0x0ED/237
        public byte JobLevels21_22;                                 // 0x0EE/238
        public byte JobLevels23;                                    // 0x0EF/239
        public ushort JobPoints1;                                   // 0x0F0/240
        public ushort JobPoints2;                                   // 0x0F2/242
        public ushort JobPoints3;                                   // 0x0F4/244
        public ushort JobPoints4;                                   // 0x0F6/246
        public ushort JobPoints5;                                   // 0x0F8/248
        public ushort JobPoints6;                                   // 0x0FA/250
        public ushort JobPoints7;                                   // 0x0FC/252
        public ushort JobPoints8;                                   // 0x0FE/254
        public ushort JobPoints9;                                   // 0x100/256
        public ushort JobPoints10;                                  // 0x102/258
        public ushort JobPoints11;                                  // 0x104/260
        public ushort JobPoints12;                                  // 0x106/262
        public ushort JobPoints13;                                  // 0x108/264
        public ushort JobPoints14;                                  // 0x10A/266
        public ushort JobPoints15;                                  // 0x10C/268
        public ushort JobPoints16;                                  // 0x10E/270
        public ushort JobPoints17;                                  // 0x110/272
        public ushort JobPoints18;                                  // 0x112/274
        public ushort JobPoints19;                                  // 0x114/276
        public ushort JobPoints20;                                  // 0x116/278
        public ushort JobPoints21;                                  // 0x118/280
        public ushort JobPoints22;                                  // 0x11A/282
        public ushort JobPoints23;                                  // 0x11C/284
        public ushort JobExp1;                                      // 0x11E/286
        public ushort JobExp2;                                      // 0x120/288
        public ushort JobExp3;                                      // 0x122/290
        public ushort JobExp4;                                      // 0x124/292
        public ushort JobExp5;                                      // 0x126/294
        public ushort JobExp6;                                      // 0x128/296
        public ushort JobExp7;                                      // 0x12A/298
        public ushort JobExp8;                                      // 0x12C/300
        public ushort JobExp9;                                      // 0x12E/302
        public ushort JobExp10;                                     // 0x130/304
        public ushort JobExp11;                                     // 0x132/306
        public ushort JobExp12;                                     // 0x134/308
        public ushort JobExp13;                                     // 0x136/310
        public ushort JobExp14;                                     // 0x138/312
        public ushort JobExp15;                                     // 0x13A/314
        public ushort JobExp16;                                     // 0x13C/316
        public ushort JobExp17;                                     // 0x13E/318
        public ushort JobExp18;                                     // 0x140/320
        public ushort JobExp19;                                     // 0x142/322
        public ushort JobExp20;                                     // 0x144/324
        public ushort JobExp21;                                     // 0x146/326
        public ushort JobExp22;                                     // 0x148/328
        public ushort JobExp23;                                     // 0x14A/330
        public fixed byte Nickname[16];                             // 0x14C/332
        public ulong Unknown348;                                    // 0x15C/348
        public ulong Unknown356;                                    // 0x164/356
        public ulong Unknown364;                                    // 0x16C/364
        public ulong Unknown372;                                    // 0x174/372
        public ulong Unknown380;                                    // 0x17C/380
        public ulong Unknown388;                                    // 0x184/388
        public byte CurrentKOCount;                                 // 0x18C/396
        public ushort ChargingCounter;                              // 0x18D/397 (0xFF = Not Charging)
        public byte PortraitId;                                     // 0x18F/399
        public byte JobPalette;                                     // 0x190/400
    }
}
