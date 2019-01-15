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

            context.People.AddOrUpdate(person);


            Methodology HS = new Methodology();
            HS.Id = 1;
            HS.Name = "Harcerze Starsi";

            context.Methodologies.AddOrUpdate(HS);

            Methodology w = new Methodology();
            w.Id = 2;
            w.Name = "Wêdrownicy";
            context.Methodologies.AddOrUpdate(w);


            Team b = new Team("Berserk", 1, HS);

            context.Teams.AddOrUpdate(b);

            Team e = new Team("Emilki", 1, w);
            context.Teams.AddOrUpdate(e);


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
