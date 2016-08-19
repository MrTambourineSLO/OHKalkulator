﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using OhKalkulator.Models;

namespace OhKalkulator.EntityConfigurations
{
    public class ObrokConfiguration :EntityTypeConfiguration<Obrok>
    {
        /*Fluent API konfiguracija za tabelo "Obroki" ter relacije le-te z drugimi tabelami*/
        public ObrokConfiguration()
        {
            ToTable("Obroki")
                .Property(p => p.ImeObroka)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(255);
            
            HasMany(p => p.PripravljeneJedi)
                .WithMany(p => p.Obroki)
                .Map(m =>
                {
                    m.ToTable("PripravljeneJediObroki");
                    m.MapLeftKey("PripravljenaJedId");
                    m.MapRightKey("ObrokId");

                });

        }
    }
}