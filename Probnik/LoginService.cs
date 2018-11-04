using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Probnik.Exceptions;

namespace Probnik
{
    public static class LoginService
    {

        public static void RegisterNewUser(User user)
        {
            using (var context = new ProbnikContext())
            {
                if (user.isValid == true)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }

            }
        }

        /// <summary>
        /// Checks if login and password match
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="password"></param>
        /// <returns>User commponent or null</returns>
        public static User Login(string Login, string password)
        {
            using (var context = new ProbnikContext())
            {
                User user = context.Users.Include(u => u.People).SingleOrDefault(u => u.Login == Login);
                if (user != null)
                    return user.PasswordMatch(password) ? user : null;
                return null;
            }
        }

        public static void CreateNewPerson(Person person)
        {
            using (var context = new ProbnikContext())
            {
                if (person.PESEL != null && !context.People.Any(p => p.PESEL == person.PESEL))
                {
                    context.People.Add(person);
                    context.SaveChanges();
                }
            }
        }

        public static bool ConnectUserToPerson(int userId, int personId, string key, ConnectionType connectionType)
        {

            using (var context = new ProbnikContext())
            {
                var person = context.People.Single(p => p.Id == personId);

                if (person.ConnectionKey == key)
                {
                    var connection = new UserToPersonConnection(userId, person.Id, connectionType);
                    context.UserToPersonConnections.Add(connection);
                    person.GenerateNewKey();
                    context.SaveChanges();
                }
            }
            return false;
        }

        public static void RegisterNewTeam(int ownerId, Team team)
        {
            using (var context = new ProbnikContext())
            {
                context.Teams.Add(team);
                context.SaveChanges();
            }
        }


    }
}
