using System.Runtime.InteropServices;

namespace fftivc.ext.beastmaster.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LEARNED_ABILITIES
    {
        public byte ActionAbilities1;   // Abilities 1-8
        public byte ActionAbilities2;   // Abilities 9-16
        public byte RSMAbilities;       // Reaction/Support/Movement Abilities
    }
}
