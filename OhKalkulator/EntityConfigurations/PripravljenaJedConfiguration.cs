using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using OhKalkulator.Models;

namespace OhKalkulator.EntityConfigurations
{
    public class PripravljenaJedConfiguration : EntityTypeConfiguration<PripravljenaJed>
    {
        public PripravljenaJedConfiguration()
        {
            ToTable("PripravljeneJedi");
            Property(p => p.Ime)
                .HasColumnType("nvarchar")
                .IsRequired();

            HasMany(p => p.Zivila)
                .WithMany(p => p.PripravljeneJedi)
                .Map(m =>
                {
                    m.ToTable("PripravljeneJediZivila");
                    m.MapLeftKey("PripravljenaJedId");
                    m.MapRightKey("ZiviloId");
                });

        }
    }
}