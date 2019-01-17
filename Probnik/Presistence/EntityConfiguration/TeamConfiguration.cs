using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(t => t.Owner)
                .WithMany()
                .HasForeignKey(t => t.OwnerId)
                .WillCascadeOnDelete(false);

            HasMany(t => t.Methodologies)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("TeamsMethodologies");
                    m.MapLeftKey("TeamId");
                    m.MapRightKey("MethodologyId");
                });

            HasMany(t => t.Patrons)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("TeamPatrons");
                    m.MapLeftKey("TeamId");
                    m.MapRightKey("PatronId");
                });

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
