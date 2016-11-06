using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using OhKalkulator.Models;

namespace OhKalkulator.EntityConfigurations
{
    public class DnevnikPrehranjevanjaConfiguration : EntityTypeConfiguration<DnevnikPrehranjevanja>
    {
        public DnevnikPrehranjevanjaConfiguration()
        {
            ToTable("DnevnikiPrehranjevanja");
            Property(p => p.Datum).HasColumnType("datetime2").IsRequired();
            Property(p => p.TipObroka).IsRequired();
            HasRequired(p => p.Obrok).WithOptional(p => p.DnevnikPrehranjevanja);

            
        }
    }
}