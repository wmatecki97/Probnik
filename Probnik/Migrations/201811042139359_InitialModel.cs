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
                        Owner_Id = c.Int(nullable: false),
                        Patron_Id = c.Int(),
                        StateId = c.Byte(nullable: false),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Owner_Id, cascadeDelete: true)
                .ForeignKey("dbo.Patrons", t => t.Patron_Id)
                .ForeignKey("dbo.TaskStates", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.TaskContents", t => t.TaskId)
                .Index(t => t.Owner_Id)
                .Index(t => t.Patron_Id)
                .Index(t => t.StateId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        PESEL = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        ConnectionKey = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.PESEL, unique: true);
            
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
                "dbo.Methodologies",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
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
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.PersonId);
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.Login, unique: true);
            
            CreateTable(
                "dbo.TaskStates",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.TeamsMethodologies",
                c => new
                    {
                        TeamId = c.Int(nullable: false),
                        MethodologyId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeamId, t.MethodologyId })
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .ForeignKey("dbo.Methodologies", t => t.MethodologyId, cascadeDelete: true)
                .Index(t => t.TeamId)
                .Index(t => t.MethodologyId);
            
            CreateTable(
                "dbo.TeamPatrons",
                c => new
                    {
                        TeamId = c.Int(nullable: false),
                        PatronId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeamId, t.PatronId })
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .ForeignKey("dbo.Patrons", t => t.PatronId, cascadeDelete: true)
                .Index(t => t.TeamId)
                .Index(t => t.PatronId);
            
            CreateTable(
                "dbo.ChallangeTypesMethodologies",
                c => new
                    {
                        ChallangeTypeId = c.Int(nullable: false),
                        MethodologyId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChallangeTypeId, t.MethodologyId })
                .ForeignKey("dbo.ChallangeTypes", t => t.ChallangeTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Methodologies", t => t.MethodologyId, cascadeDelete: true)
                .Index(t => t.ChallangeTypeId)
                .Index(t => t.MethodologyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Challanges", "TaskId", "dbo.TaskContents");
            DropForeignKey("dbo.TaskContents", "ChallangeTypeId", "dbo.ChallangeTypes");
            DropForeignKey("dbo.ChallangeTypesMethodologies", "MethodologyId", "dbo.Methodologies");
            DropForeignKey("dbo.ChallangeTypesMethodologies", "ChallangeTypeId", "dbo.ChallangeTypes");
            DropForeignKey("dbo.Challanges", "StateId", "dbo.TaskStates");
            DropForeignKey("dbo.Challanges", "Patron_Id", "dbo.Patrons");
            DropForeignKey("dbo.UserToPersonConnections", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserToPersonConnections", "PersonId", "dbo.People");
            DropForeignKey("dbo.TeamPatrons", "PatronId", "dbo.Patrons");
            DropForeignKey("dbo.TeamPatrons", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Patrons", "PersonId", "dbo.People");
            DropForeignKey("dbo.Teams", "OwnerId", "dbo.People");
            DropForeignKey("dbo.TeamsMethodologies", "MethodologyId", "dbo.Methodologies");
            DropForeignKey("dbo.TeamsMethodologies", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.PeopleInTeams", "PersonId", "dbo.People");
            DropForeignKey("dbo.PeopleInTeams", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Challanges", "Owner_Id", "dbo.People");
            DropIndex("dbo.ChallangeTypesMethodologies", new[] { "MethodologyId" });
            DropIndex("dbo.ChallangeTypesMethodologies", new[] { "ChallangeTypeId" });
            DropIndex("dbo.TeamPatrons", new[] { "PatronId" });
            DropIndex("dbo.TeamPatrons", new[] { "TeamId" });
            DropIndex("dbo.TeamsMethodologies", new[] { "MethodologyId" });
            DropIndex("dbo.TeamsMethodologies", new[] { "TeamId" });
            DropIndex("dbo.PeopleInTeams", new[] { "PersonId" });
            DropIndex("dbo.PeopleInTeams", new[] { "TeamId" });
            DropIndex("dbo.TaskContents", new[] { "ChallangeTypeId" });
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.UserToPersonConnections", new[] { "PersonId" });
            DropIndex("dbo.UserToPersonConnections", new[] { "UserId" });
            DropIndex("dbo.Patrons", new[] { "PersonId" });
            DropIndex("dbo.Teams", new[] { "OwnerId" });
            DropIndex("dbo.People", new[] { "PESEL" });
            DropIndex("dbo.Challanges", new[] { "TaskId" });
            DropIndex("dbo.Challanges", new[] { "StateId" });
            DropIndex("dbo.Challanges", new[] { "Patron_Id" });
            DropIndex("dbo.Challanges", new[] { "Owner_Id" });
            DropTable("dbo.ChallangeTypesMethodologies");
            DropTable("dbo.TeamPatrons");
            DropTable("dbo.TeamsMethodologies");
            DropTable("dbo.PeopleInTeams");
            DropTable("dbo.ChallangeTypes");
            DropTable("dbo.TaskContents");
            DropTable("dbo.TaskStates");
            DropTable("dbo.Users");
            DropTable("dbo.UserToPersonConnections");
            DropTable("dbo.Patrons");
            DropTable("dbo.Methodologies");
            DropTable("dbo.Teams");
            DropTable("dbo.People");
            DropTable("dbo.Challanges");
        }
    }
}
