using System.Data.Entity;

namespace HappySquad.Models
{
    public class Unit : BaseState
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string About { set; get; }
        public double Cost { set; get; }
        public Type Type { set; get; }
        public Race Race { set; get; }
        public int Models { set; get; }
        public string LootId { set; get; }
        public class UnitDBContext : DbContext
        {
            public DbSet<Unit> Units { get; set; }
        }
    }
}