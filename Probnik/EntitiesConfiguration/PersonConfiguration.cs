using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.EntitiesConfiguration
{
    class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            //HasMany(p => p.Teams)
            //    .WithMany()
            //    .Map(m =>
            //    {
            //        m.ToTable("PeopleInTeams");
            //        m.MapLeftKey("PersonId");
            //        m.MapRightKey("TeamId");
            //    });


            
        }
    }
}
