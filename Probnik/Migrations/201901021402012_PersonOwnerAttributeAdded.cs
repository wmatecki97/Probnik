namespace Probnik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonOwnerAttributeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "OwnerID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "OwnerID");
        }
    }
}
