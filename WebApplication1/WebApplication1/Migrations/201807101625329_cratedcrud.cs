namespace Bovoyage3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cratedcrud : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agences", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Agences", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Agences", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Clients", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clients", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Destinations", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Destinations", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Destinations", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Voyages", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Voyages", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Voyages", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Participants", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Participants", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Participants", "DeletedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Participants", "DeletedAt");
            DropColumn("dbo.Participants", "Deleted");
            DropColumn("dbo.Participants", "CreatedAt");
            DropColumn("dbo.Voyages", "DeletedAt");
            DropColumn("dbo.Voyages", "Deleted");
            DropColumn("dbo.Voyages", "CreatedAt");
            DropColumn("dbo.Destinations", "DeletedAt");
            DropColumn("dbo.Destinations", "Deleted");
            DropColumn("dbo.Destinations", "CreatedAt");
            DropColumn("dbo.Clients", "DeletedAt");
            DropColumn("dbo.Clients", "Deleted");
            DropColumn("dbo.Clients", "CreatedAt");
            DropColumn("dbo.Agences", "DeletedAt");
            DropColumn("dbo.Agences", "Deleted");
            DropColumn("dbo.Agences", "CreatedAt");
        }
    }
}
