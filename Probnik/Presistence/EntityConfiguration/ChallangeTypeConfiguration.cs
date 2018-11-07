using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.EntitiesConfiguration
{
    class ChallangeTypeConfiguration : EntityTypeConfiguration<ChallangeType>
    {
        public ChallangeTypeConfiguration()
        {
            HasMany(c => c.Methodologies)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("ChallangeTypesMethodologies");
                    m.MapLeftKey("ChallangeTypeId");
                    m.MapRightKey("MethodologyId");
                });

            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
