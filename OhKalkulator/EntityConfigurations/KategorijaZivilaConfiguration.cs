using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using OhKalkulator.Models;

namespace OhKalkulator.EntityConfigurations
{
    public class KategorijaZivilaConfiguration : EntityTypeConfiguration<KategorijaZivila>
    {
        /*===   Overridanje konvencij za tabelo KategorijaZivila  ===*/

        public KategorijaZivilaConfiguration()
        {
            ToTable("KategorijeZivil")
           .Property(p => p.Ime)
           .HasColumnType("nvarchar")
           .HasMaxLength(255)
           .IsRequired();
            /*
              ===   Overridanje konvencij za relacijo KategorijaZivila(1) -> (N)Zivila  ===
           */

            HasMany(p => p.Zivila)
                .WithRequired(p => p.KategorijaZivila)
                .HasForeignKey(f => f.KategorijaZivilaId);
        }
    }
}