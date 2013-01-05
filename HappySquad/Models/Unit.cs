namespace HappySquad.Models
{
    public class Unit : BaseState
    {
        public Type Type { get; set; }

        public Race Race { get; set; }

        public int? ToTroops { get; set; }
    }
}