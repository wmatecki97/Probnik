using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
                .WithOptional();
                //.Map(m => m.MapKey("TaskId"));

//            HasRequired(c => c.State)
//                .WithMany()
//                .Map(m => m.MapKey("StateId"));

            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //HasRequired(c => c.Owner)
            //    .WithMany()
            //    .Map(m => m.MapKey("OwnerId"));

            HasOptional(c => c.Patron)
                .WithMany()
                .HasForeignKey(c => c.PatronId);

            HasRequired(c => c.Owner)
                .WithMany()
                .Map(m => m.MapKey("OwnerId"));

        }
    }
}
