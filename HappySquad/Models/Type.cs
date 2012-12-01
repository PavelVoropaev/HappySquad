namespace HappySquad.Models
{
    using System.ComponentModel;

    public enum Type
    {
        [Description("HQ")]
        HQ,
        [Description("Trpoops")]
        Trpoops,
        [Description("Elite")]
        Elite,
        [Description("Fast Attack")]
        FastAttack,
        [Description("Heavy Support")]
        HeavySupport
    }
}