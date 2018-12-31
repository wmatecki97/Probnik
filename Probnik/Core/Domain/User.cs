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
        public string Token { get; set; }

        public ICollection<UserToPersonConnection> People { get; set; }

        public User()
        {
            People = new List<UserToPersonConnection>();
            IsAdmin = false;
            Token = Id.ToString() + RandomString(20);
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

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
