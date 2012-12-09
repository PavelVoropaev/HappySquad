namespace HappySquad.Models
{
    using System.Data.Entity;

    using HappySquad.Migrations;

    public class HappyDbContext : DbContext
    {
        public HappyDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HappyDbContext, Configuration>());
        }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Loot> Loots { get; set; }

        public DbSet<Relation> Relations { get; set; }

        public DbSet<Roster> Rosters { get; set; }
    }
}