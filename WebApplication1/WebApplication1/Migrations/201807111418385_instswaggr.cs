namespace Bovoyage3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class instswaggr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assurances", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Assurances", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Assurances", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.DossierReservation", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.DossierReservation", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.DossierReservation", "DeletedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DossierReservation", "DeletedAt");
            DropColumn("dbo.DossierReservation", "Deleted");
            DropColumn("dbo.DossierReservation", "CreatedAt");
            DropColumn("dbo.Assurances", "DeletedAt");
            DropColumn("dbo.Assurances", "Deleted");
            DropColumn("dbo.Assurances", "CreatedAt");
        }
    }
}
