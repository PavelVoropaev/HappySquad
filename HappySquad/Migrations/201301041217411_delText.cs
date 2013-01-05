namespace HappySquad.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class DelText : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Units", "Text");
            DropColumn("dbo.Loots", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Loots", "Text", c => c.String());
            AddColumn("dbo.Units", "Text", c => c.String());
        }
    }
}
