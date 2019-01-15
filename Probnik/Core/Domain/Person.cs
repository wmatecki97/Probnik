using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Probnik.Core.DTO;

namespace Probnik
{
    public class Person
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PESEL { get; set; }
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Auto generated key to connect users to this person. It is changed after use.
        /// </summary>
        public string ConnectionKey { get; set; }
        public int OwnerID { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<UserToPersonConnection> Users { get; set; }
        public virtual ICollection<Challange>  Challanges { get; set; }

        public Person(string name, string surname, string dateOfBirth): this(name, surname)
        {
            DateOfBirth = DateTime.Parse(dateOfBirth);
        }

        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
            GenerateNewKey();
            Teams = new List<Team>();
            Users = new List<UserToPersonConnection>();
            Challanges = new List<Challange>();

        }

        public Person(string name, string surname, DateTime dateOfBirth):this(name, surname)
        {
            DateOfBirth = dateOfBirth;
        }

        public Person()
        {
            
        }
            
        public Person(string name, string surname, string pesel, string dateOfBirth) : this(name, surname, dateOfBirth)
        {
            PESEL = pesel;
        }

        public void GenerateNewKey()
        {
            ConnectionKey = new Random().Next(1000,9999).ToString();
        }

        public PersonDTO ToPersonDTO()
        {
            return new PersonDTO(Id, Name, Surname, PESEL, DateOfBirth);
        }
    }
}
