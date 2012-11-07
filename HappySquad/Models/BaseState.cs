namespace HappySquad.Models
{
    public class BaseState
    {
        public byte WS { set; get; }
        public byte BS { set; get; }
        public byte S { set; get; }
        public byte T { set; get; }
        public byte W { set; get; }
        public byte I { set; get; }
        public byte A { set; get; }
        public byte Ld { set; get; }
        public byte Sv { set; get; }
        public int Id { set; get; }
        public string Name { set; get; }
        public string About { set; get; }
        public double Cost { set; get; }
        public int Models { set; get; }
    }
}