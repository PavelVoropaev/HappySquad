namespace HappySquad.Models
{
    public class Roster
    {
        public int Id { set; get; }
        public string RosterName { set; get; }
        public Race Race { set; get; }
        public byte Position { set; get; }
        public int RelationsId { set; get; }


    }
}