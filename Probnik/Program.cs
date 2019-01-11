using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Probnik.Presistence;
using Probnik.REST;

namespace Probnik
{
    class Program
    {
        static void Main(string[] args)
        {
//            Test();

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
            w.Name = "Wędrownicy";
            context.Methodologies.AddOrUpdate(w);


            Team b = new Team("Berserk", 1, HS);

            context.Teams.AddOrUpdate(b);

            Team e = new Team("Emilki", 1, w);
            context.Teams.AddOrUpdate(e);

            context.SaveChanges();

            //var unit = new UnitOfWork(context);

            //var p = unit.People.Get(0);
            //var c = new UserToPersonConnection();

            //unit.Users.Get(0);
        }
    }
}
