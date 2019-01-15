namespace Probnik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PeselIndexDeleted : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.People", new[] { "PESEL" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.People", "PESEL", unique: true);
        }
    }
}
