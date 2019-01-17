namespace Probnik.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Probnik.ProbnikContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Probnik.ProbnikContext context)
        {
            

            User user = new User();
            user.Login = "wmatecki97";
            user.Email = "wmatecki97@gmail.com";
            user.IsAdmin = true;
            user.Password = "haslotestowe";
            user.Id = 1;

            context.Users.AddOrUpdate(user);

            Person person = new Person("Wiktor", "Matecki", "18-08-1997");
            person.Id = 1;

            UserToPersonConnection upc = new UserToPersonConnection(1,1,ConnectionType.PersonToOwner);

            person.Users.Add(upc);

            
            //context.People.AddOrUpdate(person);

            //context.SaveChanges();
            
            Methodology HS = new Methodology();
            HS.Name = "Harcerze Starsi";
            HS.Id = 1;

            //context.Methodologies.AddOrUpdate(HS);

            Methodology w = new Methodology();
            w.Name = "Wêdrownicy";
            w.Id = 2;
            //context.Methodologies.AddOrUpdate(w);

            Patron patron = new Patron();
            patron.Person = person;
            patron.Id = 1;

            Team b = new Team();
            b.Name = "Berserk";
            b.Methodologies.Add(HS);
            b.Patrons.Add(patron);
            b.Owner = person;
            b.Id = 1;

            context.Teams.AddOrUpdate(b);

            Team e = new Team();
            e.Name = "Emilki";
            e.Methodologies.Add(w);
            context.Teams.AddOrUpdate(e);
            e.Owner = person;
            e.Id = 2;

            //context.SaveChanges();

            //HS = context.Methodologies.First(m => m.Name == "Harcerze Starsi");
            TaskContent task1 = new TaskContent();
            task1.Content = "Wyzwanie sportowe";
            task1.TaskNumber = 1;

            var task2 = new TaskContent()
            {
                Content = "Wyzwanie duchowe",
                TaskNumber = 2
            };

            ChallangeType challengeType = new ChallangeType();
            challengeType.Methodologies.Add(HS);
            challengeType.Name = "Odkrywca";
            challengeType.Tasks.Add(task1);
            challengeType.Tasks.Add(task2);

            context.ChallangeTypes.Add(challengeType);

            context.SaveChanges();
            
            

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
