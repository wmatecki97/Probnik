using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Probnik.Presistence;

namespace Probnik.REST
{
    class Session
    {
        public ProbnikContext context { get; set; }
        public string token
        {
            get
            {
                if (user != null)
                    return user.Token;
                else
                    return null;
            }
        }

        public User user { get; set; }

        public Session(User user)
        {
            this.user = user;
            context = new ProbnikContext();
        }

        public Session(string login, string password)
        {
            context = new ProbnikContext();
            UnitOfWork unit = new UnitOfWork(context);

            user = unit.Users.Find(u => u.Login == login && u.Password == password).FirstOrDefault();

            if (user != null)
            {
                SessionManager.AddSession(this);
            }
        }
    }
}
