namespace HappySquad.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ConvertToTroops : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Units", "ToTroops", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Units", "ToTroops", c => c.String());
        }
    }
}
