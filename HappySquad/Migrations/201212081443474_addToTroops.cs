namespace HappySquad.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddToTroops : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Units", "ToTroops", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Units", "ToTroops");
        }
    }
}
