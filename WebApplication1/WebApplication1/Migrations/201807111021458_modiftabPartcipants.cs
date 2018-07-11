namespace Bovoyage3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modiftabPartcipants : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Participants", "NumeroUnique");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Participants", "NumeroUnique", c => c.Int(nullable: false));
        }
    }
}
