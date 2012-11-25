namespace HappySquad.Models
{
    using System.Data.Entity;

    public class HappyDbContext : DbContext
    {
        public DbSet<Unit> Units { get; set; }

        public DbSet<Loot> Loots { get; set; }

        public DbSet<Relation> Relations { get; set; }

        public DbSet<Roster> Rosters { get; set; }
    }
}