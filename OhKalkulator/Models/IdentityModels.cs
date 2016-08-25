using System.Collections.Generic;
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

        public DnevnikPrehranjevanja DnevnikPrehranjevanja { get; set; }
        //Vsak uporabnik ima poleg vgrajenih kategorij živil še zbirko svojih
        public ICollection<KategorijaZivila> KategorijeZivil { get; set; }
        //Vsak uporabnik ima poleg vgrajenih živil še zbirko svojih
        public ICollection<Zivilo> Zivila { get; set; }
        //Vsak uporabnik ima poleg vgrajenih pripravljenih jedi še zbirko svojih
        public ICollection<PripravljenaJed> PripravljeneJedi{ get; set; }
        //Vsak uporabnik ima poleg vgrajenih obrokov še zbirko svojih
        public ICollection<Obrok> Obroki { get; set; }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /*Tabele code-first za EF*/
        public DbSet<Zivilo> Zivila { get; set; }
        public DbSet<KategorijaZivila> KategorijeZivil { get; set; }
        public DbSet<PripravljenaJed> PripravljeneJedi { get; set; }
        public DbSet<DomacaMera> DomaceMere { get; set; }
        public DbSet<Obrok> Obroki { get; set; }
        public DbSet<DnevnikPrehranjevanja> DnevnikiPrehranjevanja { get; set; }
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
            modelBuilder.Configurations.Add(new PripravljenaJedConfiguration());
            modelBuilder.Configurations.Add(new ObrokConfiguration());
            modelBuilder.Configurations.Add(new DnevnikPrehranjevanjaConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
        
    }
 
}