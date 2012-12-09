namespace HappySquad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRosterColum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rosters", "RosterId", c => c.Int(nullable: false));
            AddColumn("dbo.Rosters", "TotalCost", c => c.Int(nullable: false));
            AddColumn("dbo.Rosters", "UnitId", c => c.Int(nullable: false));
            AddColumn("dbo.Rosters", "LootId", c => c.String());
            DropColumn("dbo.Rosters", "Position");
            DropColumn("dbo.Rosters", "RelationsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rosters", "RelationsId", c => c.Int(nullable: false));
            AddColumn("dbo.Rosters", "Position", c => c.Byte(nullable: false));
            DropColumn("dbo.Rosters", "LootId");
            DropColumn("dbo.Rosters", "UnitId");
            DropColumn("dbo.Rosters", "TotalCost");
            DropColumn("dbo.Rosters", "RosterId");
        }
    }
}
