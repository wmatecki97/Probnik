namespace Probnik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeamsMethodologies", "MethodologyId", "dbo.Methodologies");
            DropForeignKey("dbo.ChallangeTypesMethodologies", "MethodologyId", "dbo.Methodologies");
            DropIndex("dbo.Challanges", new[] { "Id" });
            DropPrimaryKey("dbo.Challanges");
            DropPrimaryKey("dbo.Methodologies");
            AlterColumn("dbo.Challanges", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Methodologies", "Id", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.Challanges", "Id");
            AddPrimaryKey("dbo.Methodologies", "Id");
            CreateIndex("dbo.Challanges", "Id");
            AddForeignKey("dbo.TeamsMethodologies", "MethodologyId", "dbo.Methodologies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ChallangeTypesMethodologies", "MethodologyId", "dbo.Methodologies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChallangeTypesMethodologies", "MethodologyId", "dbo.Methodologies");
            DropForeignKey("dbo.TeamsMethodologies", "MethodologyId", "dbo.Methodologies");
            DropIndex("dbo.Challanges", new[] { "Id" });
            DropPrimaryKey("dbo.Methodologies");
            DropPrimaryKey("dbo.Challanges");
            AlterColumn("dbo.Methodologies", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Challanges", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Methodologies", "Id");
            AddPrimaryKey("dbo.Challanges", "Id");
            CreateIndex("dbo.Challanges", "Id");
            AddForeignKey("dbo.ChallangeTypesMethodologies", "MethodologyId", "dbo.Methodologies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TeamsMethodologies", "MethodologyId", "dbo.Methodologies", "Id", cascadeDelete: true);
        }
    }
}
