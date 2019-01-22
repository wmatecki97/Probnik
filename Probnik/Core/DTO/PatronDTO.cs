using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Core.DTO
{
    public class PatronDTO
    {
        public PersonDTO Person { get; set; }
        public int? Id { get; set; }

        public PatronDTO()
        {
        }

        public PatronDTO(Patron p)
        {
            Person = p.Person.ToPersonDTO();
            Id = p.Id;
        }
    }
}
