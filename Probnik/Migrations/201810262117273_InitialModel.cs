namespace Probnik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Challanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mission = c.String(),
                        State = c.Byte(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        PatronId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.OwnerId)
                .ForeignKey("dbo.Patrons", t => t.PatronId)
                .ForeignKey("dbo.TaskContents", t => t.TaskId)
                .Index(t => t.OwnerId)
                .Index(t => t.PatronId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.UserToPersonConnections",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        ConnectionType = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patrons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.TaskContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        ChallangeTypeId = c.Int(nullable: false),
                        TaskNumber = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChallangeTypes", t => t.ChallangeTypeId, cascadeDelete: true)
                .Index(t => t.ChallangeTypeId);
            
            CreateTable(
                "dbo.ChallangeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PeopleInTeams",
                c => new
                    {
                        TeamId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeamId, t.PersonId })
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.TeamId)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Challanges", "TaskId", "dbo.TaskContents");
            DropForeignKey("dbo.TaskContents", "ChallangeTypeId", "dbo.ChallangeTypes");
            DropForeignKey("dbo.Challanges", "PatronId", "dbo.Patrons");
            DropForeignKey("dbo.Patrons", "PersonId", "dbo.People");
            DropForeignKey("dbo.Challanges", "OwnerId", "dbo.People");
            DropForeignKey("dbo.UserToPersonConnections", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserToPersonConnections", "PersonId", "dbo.People");
            DropForeignKey("dbo.Teams", "OwnerId", "dbo.People");
            DropForeignKey("dbo.PeopleInTeams", "PersonId", "dbo.People");
            DropForeignKey("dbo.PeopleInTeams", "TeamId", "dbo.Teams");
            DropIndex("dbo.PeopleInTeams", new[] { "PersonId" });
            DropIndex("dbo.PeopleInTeams", new[] { "TeamId" });
            DropIndex("dbo.TaskContents", new[] { "ChallangeTypeId" });
            DropIndex("dbo.Patrons", new[] { "PersonId" });
            DropIndex("dbo.UserToPersonConnections", new[] { "PersonId" });
            DropIndex("dbo.UserToPersonConnections", new[] { "UserId" });
            DropIndex("dbo.Teams", new[] { "OwnerId" });
            DropIndex("dbo.Challanges", new[] { "TaskId" });
            DropIndex("dbo.Challanges", new[] { "PatronId" });
            DropIndex("dbo.Challanges", new[] { "OwnerId" });
            DropTable("dbo.PeopleInTeams");
            DropTable("dbo.ChallangeTypes");
            DropTable("dbo.TaskContents");
            DropTable("dbo.Patrons");
            DropTable("dbo.Users");
            DropTable("dbo.UserToPersonConnections");
            DropTable("dbo.Teams");
            DropTable("dbo.People");
            DropTable("dbo.Challanges");
        }
    }
}
