using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using OhKalkulator.Models;

namespace OhKalkulator.EntityConfigurations
{
    public class DomacaMeraConfiguration : EntityTypeConfiguration<DomacaMera>
    {
        /*===   Overridanje konvencij za tabelo DomacaMera  ===*/
        public DomacaMeraConfiguration()
        
        
        {
            ToTable("DomaceMere")
                .Property(p => p.ImeMere)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(255);

            /*===   Overridanje konvencij za relacijo DomacaMera(1) -> (N)Zivila  ===*/
            

            HasMany(p => p.Zivila)
                .WithRequired(p => p.DomacaMera)
                .HasForeignKey(f => f.DomacaMeraId);
        }
    }
}