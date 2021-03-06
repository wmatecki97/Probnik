﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.EntitiesConfiguration
{
    public class TaskContentConfiguration : EntityTypeConfiguration<TaskContent>
    {
        public TaskContentConfiguration()
        {
            HasRequired(t => t.ChallangeType)
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => t.ChallangeTypeId);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
