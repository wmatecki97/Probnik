using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Probnik.Core.DTO;

namespace Probnik
{
    public class Patron
    {
        public Person Person { get; set; }
        public int? Id { get; set; }
//        public ICollection<Challange> ChallangesPatron { get; set; }

        public Patron()
        {
        }

        public PatronDTO ToPatronDTO()
        {
            return new PatronDTO(this);
        }
    }
}
