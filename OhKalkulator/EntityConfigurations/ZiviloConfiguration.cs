using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using OhKalkulator.Models;


namespace OhKalkulator.EntityConfigurations
{
    public class ZiviloConfiguration : EntityTypeConfiguration<Zivilo>
    {
        /*===   Overridanje konvencij za tabelo Zivila  ===*/
        
        public ZiviloConfiguration()
        {
                ToTable("Zivila")
                .Property(p => p.Ime)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(255);

                 Property(p => p.OhKoeficient).IsRequired();
            
                 Property(p => p.SifraGorenje)
                .IsOptional();
            Property(p => p.UporabnikId).HasMaxLength(128);

            HasOptional(p => p.Uporabnik).WithMany(p => p.Zivila).HasForeignKey(f => f.UporabnikId);
        }

    }
}