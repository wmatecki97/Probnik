using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<UserToPersonConnection> People { get; set; }

        public User()
        {
        }
        public User(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
            IsAdmin = false;
        }

        public bool isValid
        {
            get
            {
                return Login.Length > 8 
                       && Password.Length > 8 
                       && Email.Contains('@') 
                       && Email.Length > 8;
            }
        }

        public bool PasswordMatch(string password)
        {
            return password == Password;
        }
    }
}
