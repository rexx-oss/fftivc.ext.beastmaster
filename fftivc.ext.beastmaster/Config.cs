using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using fftivc.ext.beastmaster.Template.Configuration;
using Reloaded.Mod.Interfaces.Structs;

namespace fftivc.ext.beastmaster.Configuration
{
    public class Config : Configurable<Config>
    {
        [Category("Beastmaster")]
        [DisplayName("Global Beastmaster")]
        [Description("Skip Beastmaster check (all monster Beastmaster checks succeed).")]
        [DefaultValue(true)]
        public bool SkipBeastmasterCheck { get; set; } = false;

        [Category("Beastmaster")]
        [DisplayName("Infinite Range")]
        [Description("Extend the range of Beastmaster to the entire map. Vertical limits are ignored.")]
        [DefaultValue(true)]
        public bool InfiniteBeastmasterRange { get; set; } = true;

        [Category("Beastmaster")]
        [DisplayName("Range")]
        [Description("Set the range of Beastmaster. Normal vertical limits still apply.")]
        [SliderControlParams(minimum: 1, maximum: 8, tickFrequency: 1, showTextField: true)]
        [DefaultValue(1)]
        public int BeastmasterRange { get; set; } = 1;
    }

    /// <summary>
    /// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
    /// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
    /// </summary>
    public class ConfiguratorMixin : ConfiguratorMixinBase
    {
        // 
    }
}
