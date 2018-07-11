namespace Bovoyage3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modiftablepersonne : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Civilite", c => c.String());
            AlterColumn("dbo.Participants", "Civilite", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Participants", "Civilite", c => c.Byte(nullable: false));
            AlterColumn("dbo.Clients", "Civilite", c => c.Byte(nullable: false));
        }
    }
}
