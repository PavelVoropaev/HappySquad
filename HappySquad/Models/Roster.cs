namespace HappySquad.Models
{
    public class Roster
    {
        public int Id { get; set; }

        public string RosterName { get; set; }

        public Race Race { get; set; }

        public byte Position { get; set; }

        public int RelationsId { get; set; }
    }
}