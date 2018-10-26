using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.EntitiesConfiguration
{
    class ChallangeConfiguration : EntityTypeConfiguration<Challange>
    {
        public ChallangeConfiguration()
        {
            //HasRequired(c => c.Patron)
            //    .WithMany()
            //    .Map(m => m.MapKey("PatronId"));

            HasRequired(c => c.Task)
                .WithOptional()
                .Map(m => m.MapKey("TaskId"));

            HasRequired(c => c.State)
                .WithMany()
                .Map(m => m.MapKey("StateId"));

            //HasRequired(c => c.Owner)
            //    .WithMany()
            //    .Map(m => m.MapKey("OwnerId"));


        }
    }
}
