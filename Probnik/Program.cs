using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Probnik.Presistence;
using Probnik.Presistence.Repositories;

namespace Probnik
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //PopulateDatebase();
        }

        private static void PopulateDatebase()
        {
            using (ProbnikContext context = new ProbnikContext())
            {
                UnitOfWork unit = new UnitOfWork(context);


                var wiktor = new Person("Wiktor", "Matecki", "97081801097", "1997-08-18");

                unit.People.Add(new Person("Zofia", "Gmerek", "1997-07-29"));
                unit.People.Add(wiktor);

                context.SaveChanges();


                User user = new User("admin", "admin", "admin@probnik.cs");
                var person = unit.People.GetPersonByPesel("97081801097");

                UserToPersonConnection connectedPerson =
                    new UserToPersonConnection(user.Id.Value, person.Id.Value, ConnectionType.PersonToOwner);
                user.People = new List<UserToPersonConnection>();
                user.People.Add(connectedPerson);
             //   if (user.isValid)
                    unit.Users.Add(user);


                unit.Methodologies.Add(new Methodology("Z"));
                unit.Methodologies.Add(new Methodology("H"));
                Methodology hs = new Methodology("HS");
                unit.Methodologies.Add(new Methodology("W"));
                unit.Methodologies.Add(new Methodology("I"));

                Team team = new Team("Berserk", person.Id.Value, hs);
                unit.Teams.Add(team);

                TaskContent task1 = new TaskContent();
                task1.Content = "Wyzwanie sportowe";
                task1.TaskNumber = 1;

                var task2 = new TaskContent()
                {
                    Content = "Wyzwanie duchowe",
                    TaskNumber = 2
                };

                ChallangeType challengeType = new ChallangeType();
                challengeType.Methodologies.Add(hs);
                challengeType.Name = "Odkrywca";
                challengeType.Tasks.Add(task1);
                challengeType.Tasks.Add(task2);

                unit.Complete();
            }
        }
    }
}
