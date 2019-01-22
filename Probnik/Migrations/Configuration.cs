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

            User probant = new User();
            probant.Login = "probant";
            probant.Email = "probant@probnik.com";
            probant.IsAdmin = false;
            probant.Password = "haslotestowe";
            probant.Id = 2;
            context.Users.AddOrUpdate(probant);


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
            task1.Content = "W³¹czy³em siê do prowadzenia gospodarstwa domowego. W trakcie próby przej¹³em na siebie dodatkowe obowi¹zki";
            task1.TaskNumber = 1;
            task1.Id = 2;
            task1.ChallangeTypeId = 1;

            var task2 = new TaskContent()
            {
                Content = "Jestem wra¿liwy na potrzeby drugiego cz³owieka – œwiadomie i odpowiedzialnie podejmujê sta³¹ s³u¿bê.",
                TaskNumber = 2,
                Id = 1,
                ChallangeTypeId = 1
            };

            ChallangeType challengeType = new ChallangeType();
            challengeType.Methodologies.Add(HS);
            challengeType.Name = "Odkrywca";
            challengeType.Tasks.Add(task1);
            challengeType.Tasks.Add(task2);
            challengeType.Id = 1;

            context.ChallangeTypes.AddOrUpdate(challengeType);

            TaskContent task3 = new TaskContent();
            task3.Content = "Orientuje siê w bie¿¹cych wydarzeniach politycznych, gospodarczych i kulturalnych kraju.";
            task3.TaskNumber = 1;
            task3.Id = 3;
            task3.ChallangeTypeId=2;

            var task4 = new TaskContent()
            {
                Content = "Znam najwa¿niejsze prawa i obowi¹zki obywateli RP. ",
                TaskNumber = 2,
                Id = 4,
                ChallangeTypeId = 2
            };

            ChallangeType challengeType2 = new ChallangeType();
            challengeType2.Methodologies.Add(w);
            challengeType2.Name = "Samarytanka";
            challengeType2.Tasks.Add(task3);
            challengeType2.Tasks.Add(task4);
            challengeType2.Id = 2;



            context.ChallangeTypes.AddOrUpdate(challengeType2);

            context.SaveChanges();
            
            

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
