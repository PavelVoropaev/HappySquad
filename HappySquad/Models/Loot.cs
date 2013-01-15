namespace HappySquad.Models
{
    using System.ComponentModel;

    public class Loot : BaseState
    {
        [DisplayName("Тип Снаряжения")]
        public string Type { get; set; }

        public byte Range { get; set; }

        public byte AP { get; set; }
    }
}