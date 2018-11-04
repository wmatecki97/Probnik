using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.EntitiesConfiguration
{
    class UserToPersonConnectionConfiguration : EntityTypeConfiguration<UserToPersonConnection>
    {
        public UserToPersonConnectionConfiguration()
        {
            HasRequired(c => c.Person)
                .WithMany(p => p.Users)
                .HasForeignKey(c => c.PersonId);

            HasRequired(c => c.User)
                .WithMany(u => u.People)
                .HasForeignKey(c => c.UserId);
        }
    }
}
