using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Core.DTO
{
    class UserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }

        public List<Person> ConnectedPeople;

        public UserDTO(User user)
        {
            Id = user.Id.Value;
            Login = user.Login;
            Password = user.Password;
            Email = user.Email;
            IsAdmin = user.IsAdmin;
            Token = user.Token;

            ConnectedPeople = new List<Person>();

            foreach (var connection in user.People)
            {
                ConnectedPeople.Add(connection.Person);
            }
        }

        public UserDTO()
        {
        }

       

    }
}
