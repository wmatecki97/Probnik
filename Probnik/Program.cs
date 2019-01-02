using System;
using System.Collections.Generic;
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
            Server.Start();

            Test();
        }

        private static void Test()
        {
            //var context = new ProbnikContext();
            //var unit = new UnitOfWork(context);

            //var p = unit.People.Get(0);
            //var c = new UserToPersonConnection();

            //unit.Users.Get(0);
        }
    }
}
