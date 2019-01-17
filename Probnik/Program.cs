using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Probnik.Presistence;
using Probnik.REST;
using Probnik.Presistence.Repositories;

namespace Probnik
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test();

            Server.Start();

        }

        private static void Test()
        {
            var context = new ProbnikContext();

            User user = new User();
            user.Login = "wmatecki97";
            user.Email = "wmatecki97@gmail.com";
            user.IsAdmin = true;
            user.Password = "haslotestowe";

            //context.Users.AddOrUpdate(user);

            Person person = new Person("Wiktor", "Matecki", "18-08-1997");

//            UserToPersonConnection upc = new UserToPersonConnection();
//            upc.User = user;
//            upc.Person = person;
//
//            person.Users.Add(upc);


            //context.People.AddOrUpdate(person);

            //context.SaveChanges();

            Methodology HS = new Methodology();
            HS.Name = "Harcerze Starsi";

            //context.Methodologies.AddOrUpdate(HS);

            Methodology w = new Methodology();
            w.Name = "Wędrownicy";
            //context.Methodologies.AddOrUpdate(w);

            Patron patron = new Patron();
            patron.Person = person;

            Team b = new Team();
            b.Name = "Berserk";
            b.Methodologies.Add(HS);
            b.Patrons.Add(patron);

            context.Teams.AddOrUpdate(b);

            Team e = new Team();
            e.Name = "Emilki";
            e.Methodologies.Add(w);
            context.Teams.AddOrUpdate(e);

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

            //var unit = new UnitOfWork(context);

            //var p = unit.People.Get(0);
            //var c = new UserToPersonConnection();

            //unit.Users.Get(0);
        }
    }
}
