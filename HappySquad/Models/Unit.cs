namespace HappySquad.Models
{
    using System.ComponentModel;

    public class Unit : BaseState
    {
        [DisplayName("Тип Юнита")]
        public Type Type { get; set; }

        [DisplayName("Раса")]
        public Race Race { get; set; }

        public int? ToTroops { get; set; }
    }
}