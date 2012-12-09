namespace HappySquad.Models
{
    public class BaseState
    {
        public byte WS { get; set; }

        public byte BS { get; set; }

        public byte S { get; set; }

        public byte T { get; set; }

        public byte W { get; set; }

        public byte I { get; set; }

        public byte A { get; set; }

        public byte Ld { get; set; }

        public byte Sv { get; set; }

        public byte ISv { get; set; }

        public byte ArmorF { get; set; }

        public byte ArmorS { get; set; }

        public byte ArmorR { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        public double Cost { get; set; }

        public int Models { get; set; }

        public string Text { get; set; }
    }
}