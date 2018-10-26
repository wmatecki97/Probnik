using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Probnik.EntitiesConfiguration;

namespace Probnik
{
    class ProbnikContext : DbContext
    {
        public ProbnikContext() : base("Probnik")
        {
            
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserToPersonConnection> UserToEPersonConnections { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<TaskContent> TaskContents { get; set; }
        public DbSet<ChallangeType> ChallangeTypes { get; set; }
        public DbSet<Challange> Challanges { get; set; }
        public DbSet<Methodology> Methodologies { get; set; }
        public DbSet<TaskState> TaskStateses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new UserToPersonConnectionConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new PatronConfiguration());
            modelBuilder.Configurations.Add(new TaskContentConfiguration());
            modelBuilder.Configurations.Add(new ChallangeConfiguration());
            modelBuilder.Configurations.Add(new TeamConfiguration());
            modelBuilder.Configurations.Add(new ChallangeTypeConfiguration());

        }

    }
}
