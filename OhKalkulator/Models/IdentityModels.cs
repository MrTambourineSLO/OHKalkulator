using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            //Nvarchar za Šumnike in sičnike
            
            /*
                ===   Overridanje konvencij za tabelo Zivila  ===
             */
            modelBuilder.Entity<Zivilo>()
                .ToTable("Zivila")
                .Property(p => p.Ime)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(255);
            
            modelBuilder.Entity<Zivilo>()
                .Property(p => p.OhKoeficient).IsRequired();
            modelBuilder.Entity<Zivilo>()
                .Property(p => p.SifraGorenje)
                .IsOptional();
            /*
               ===   Overridanje konvencij za tabelo KategorijaZivila  ===
            */
            modelBuilder.Entity<KategorijaZivila>()
                .ToTable("KategorijeZivil")
                .Property(p => p.Ime)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired();
            
            /*
               ===   Overridanje konvencij za relacijo KategorijaZivila(1) -> (N)Zivila  ===
            */

            modelBuilder.Entity<KategorijaZivila>()
                .HasMany(p => p.Zivila).WithRequired(p => p.KategorijaZivila)
                .HasForeignKey(f => f.KategorijaZivilaId);








        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
        
    }
 
}