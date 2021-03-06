﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.EntitiesConfiguration
{
    public class PatronConfiguration : EntityTypeConfiguration<Patron>
    {
        public PatronConfiguration()
        {
            HasRequired(p => p.Person)
                .WithOptional()
                .Map(m => m.MapKey("PersonId"));

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
