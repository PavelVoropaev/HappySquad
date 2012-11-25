namespace HappySquad.Models
{
    using System.ComponentModel;

    public enum Race
    {
        [Description("Space Marines")]
        SpaceMarines = 0,
        [Description("Imperial Guard")]
        ImperialGuard,
        [Description("Sisters Of Battle")]
        SistersOfBattle,
        [Description("Grey Knights")]
        GreyKnights,
        [Description("Blood Angels")]
        BloodAngels,
        [Description("Space Wolves")]
        SpaceWolves,
        [Description("Daemon hunters")]
        DaemonHunters,
        [Description("Chaos Space Marines")]
        ChaosSpaceMarines,
        [Description("Chaos Daemons")]
        ChaosDaemons,
        [Description("Orks")]
        Orks,
        [Description("Tyranids")]
        Tyranids,
        [Description("Dark Eldar")]
        DarkEldar,
        [Description("Eldar")]
        Eldar,
        [Description("Tau")]
        Tau,
        [Description("Necrons")]
        Necrons
    }
}