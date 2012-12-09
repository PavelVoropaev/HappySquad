namespace HappySquad.Models
{
    public class Roster
    {
        public int Id { get; set; }

        public int RosterId { get; set; }

        public string RosterName { get; set; }

        public Race Race { get; set; }

        public int TotalCost { get; set; }

        public int UnitId { get; set; }

        public string LootId { get; set; }
    }
}