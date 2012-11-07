using System.Data.Entity;

namespace HappySquad.Models
{
    public class HappyDbContext : DbContext
    {
        public DbSet<Unit> Units { get; set; }
        public DbSet<Loot> Loots { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<Roster> Rosters { get; set; }
    }
}