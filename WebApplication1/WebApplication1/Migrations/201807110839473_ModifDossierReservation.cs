namespace Bovoyage3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifDossierReservation : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DossierReservation", "Etat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DossierReservation", "Etat", c => c.Byte(nullable: false));
        }
    }
}
