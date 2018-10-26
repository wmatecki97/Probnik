using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.EntitiesConfiguration
{
    public class PatronConfiguration : EntityTypeConfiguration<Patron>
    {
        public PatronConfiguration()
        {
            HasRequired(p => p.Person)
                .WithMany()
                .Map(m => m.MapKey("PersonId"));
        }
    }
}
