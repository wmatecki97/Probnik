using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.EntitiesConfiguration
{
    class TeamConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            HasMany(t => t.Members)
                .WithMany(m => m.Teams)
                .Map(m =>
                {
                    m.ToTable("PeopleInTeams");
                    m.MapLeftKey("TeamId");
                    m.MapRightKey("PersonId");
                });

            HasRequired(t => t.Owner)
                .WithMany()
                .HasForeignKey(t => t.OwnerId)
                .WillCascadeOnDelete(false);
        }
    }
}
