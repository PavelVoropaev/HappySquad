namespace HappySquad.Models
{
    public class Loot : BaseState
    {
        public string Type { get; set; }

        public byte Range { get; set; }

        public byte AP { get; set; }
    }
}