namespace HappySquad.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Race = c.Int(nullable: false),
                        WS = c.Byte(nullable: false),
                        BS = c.Byte(nullable: false),
                        S = c.Byte(nullable: false),
                        T = c.Byte(nullable: false),
                        W = c.Byte(nullable: false),
                        I = c.Byte(nullable: false),
                        A = c.Byte(nullable: false),
                        Ld = c.Byte(nullable: false),
                        Sv = c.Byte(nullable: false),
                        Name = c.String(),
                        About = c.String(),
                        Cost = c.Double(nullable: false),
                        Models = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Loots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        WS = c.Byte(nullable: false),
                        BS = c.Byte(nullable: false),
                        S = c.Byte(nullable: false),
                        T = c.Byte(nullable: false),
                        W = c.Byte(nullable: false),
                        I = c.Byte(nullable: false),
                        A = c.Byte(nullable: false),
                        Ld = c.Byte(nullable: false),
                        Sv = c.Byte(nullable: false),
                        Name = c.String(),
                        About = c.String(),
                        Cost = c.Double(nullable: false),
                        Models = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Relations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitId = c.Int(nullable: false),
                        LootId = c.Int(nullable: false),
                        AddLootId = c.String(),
                        ExLootId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rosters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RosterName = c.String(),
                        Race = c.Int(nullable: false),
                        Position = c.Byte(nullable: false),
                        RelationsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Rosters");
            DropTable("dbo.Relations");
            DropTable("dbo.Loots");
            DropTable("dbo.Units");
        }
    }
}
