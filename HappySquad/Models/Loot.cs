using System.Data.Entity;

namespace HappySquad.Models
{
    public class Loot : BaseState
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string About { set; get; }
        public double Cost { set; get; }
        public string Type { set; get; }
        public string Excludes { set; get; }

        public class LootDBContext : DbContext
        {
            public DbSet<Loot> Loots { get; set; }
        }
    }
}