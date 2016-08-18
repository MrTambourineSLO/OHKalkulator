using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OhKalkulator.EntityConfigurations;
using OhKalkulator.Models;

namespace OhKalkulator.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Zivilo> Zivila { get; set; }
        public DbSet<KategorijaZivila> KategorijeZivil { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        // Uporabimo FluentAPI da overridamo Code First konvencije EF (bolj fleksibilna rešitev kot Data Annotations)
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API konfiguracijo sem premaknil v lastne razrede za vsako tabelo
            modelBuilder.Configurations.Add(new ZiviloConfiguration());
            modelBuilder.Configurations.Add(new KategorijaZivilaConfiguration());
            modelBuilder.Configurations.Add(new DomacaMeraConfiguration());

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
        
    }
 
}