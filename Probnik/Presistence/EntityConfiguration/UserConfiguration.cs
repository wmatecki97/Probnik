using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Presistence.EntityConfiguration
{
    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.Login).HasMaxLength(50);
            HasIndex(u => u.Login).IsUnique();

            Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


        }
    }
}
