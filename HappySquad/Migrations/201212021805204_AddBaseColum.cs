namespace HappySquad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBaseColum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Units", "ISv", c => c.Byte(nullable: false));
            AddColumn("dbo.Units", "ArmorF", c => c.Byte(nullable: false));
            AddColumn("dbo.Units", "ArmorS", c => c.Byte(nullable: false));
            AddColumn("dbo.Units", "ArmorR", c => c.Byte(nullable: false));
            AddColumn("dbo.Units", "Text", c => c.String());
            AddColumn("dbo.Loots", "Range", c => c.Byte(nullable: false));
            AddColumn("dbo.Loots", "AP", c => c.Byte(nullable: false));
            AddColumn("dbo.Loots", "ISv", c => c.Byte(nullable: false));
            AddColumn("dbo.Loots", "Strength", c => c.Byte(nullable: false));
            AddColumn("dbo.Loots", "ArmorF", c => c.Byte(nullable: false));
            AddColumn("dbo.Loots", "ArmorS", c => c.Byte(nullable: false));
            AddColumn("dbo.Loots", "ArmorR", c => c.Byte(nullable: false));
            AddColumn("dbo.Loots", "Text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Loots", "Text");
            DropColumn("dbo.Loots", "ArmorR");
            DropColumn("dbo.Loots", "ArmorS");
            DropColumn("dbo.Loots", "ArmorF");
            DropColumn("dbo.Loots", "Strength");
            DropColumn("dbo.Loots", "ISv");
            DropColumn("dbo.Loots", "AP");
            DropColumn("dbo.Loots", "Range");
            DropColumn("dbo.Units", "Text");
            DropColumn("dbo.Units", "ArmorR");
            DropColumn("dbo.Units", "ArmorS");
            DropColumn("dbo.Units", "ArmorF");
            DropColumn("dbo.Units", "ISv");
        }
    }
}
