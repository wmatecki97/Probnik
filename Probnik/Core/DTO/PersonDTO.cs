using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Core.DTO
{
    public class PersonDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PESEL { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Person ToPerson()
        {
            var person = new Person(Name, Surname);
            person.DateOfBirth = DateOfBirth;
            person.Id = Id;
            return person;
        }

        public PersonDTO()
        {
        }

        public PersonDTO(int? id, string name, string surname, string PESEL, DateTime dateOfBirth)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.PESEL = PESEL;
            this.DateOfBirth = dateOfBirth;
        }
    }

   
}
