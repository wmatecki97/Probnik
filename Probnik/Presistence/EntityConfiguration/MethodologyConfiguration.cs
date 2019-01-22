using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Presistence.EntityConfiguration
{
    class MethodologyConfiguration: EntityTypeConfiguration<Methodology>
    {
        public MethodologyConfiguration()
        {
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
