using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using OhKalkulator.Models;

namespace OhKalkulator.EntityConfigurations
{
    public class ApplicationUserConfiguration :EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            HasRequired(p => p.DnevnikPrehranjevanja).WithRequiredPrincipal(p => p.Uporabnik);
        }
    }
}