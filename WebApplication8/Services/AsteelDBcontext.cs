using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Services
{
    public class AsteelDBcontext : IdentityDbContext
    {
        public AsteelDBcontext(DbContextOptions<AsteelDBcontext> options)
          : base(options)
        {
        }
        public DbSet<Employe> Employes { get; set; }
       public DbSet<Materiel> Materiels { get; set; }
      // public DbSet<User> Users { get; set; }
       public DbSet<Affectation> Affectations { get; set; }
        public DbSet<BonDentre> BonDentres { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("AspNetUsers");
            // Materiel entity configuration
            modelBuilder.Entity<Materiel>()
            .ToTable("Materiel")
            .HasKey(m => m.IdMat);

            modelBuilder.Entity<Materiel>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Materiel>("Materiel")
                .HasValue<MatReseau>("MatReseau");
            modelBuilder.Entity<Materiel>()
          .HasOne(m => m.fournisseur)
          .WithMany(f => f.materiel)
          .HasForeignKey(m => m.codefiscale);

            // User entity configuration
            /* modelBuilder.Entity<User>()
                 .ToTable("User")
                 .HasKey(u => u.IdUser);

             // Assuming each User has one Employe
             modelBuilder.Entity<User>()
                 .HasOne(u => u.Employe)
                 .WithMany(e => e.Users)
                 .HasForeignKey(u => u.IdEmp);*/

            // Affectation entity configuration
            modelBuilder.Entity<Affectation>()
                .ToTable("Affectation")
                .HasKey(a => new { a.IdUserAffecting, a.IdEmpAffected, a.IdMat })
                ; // Composite key

            // Relationships within Affectation
            modelBuilder.Entity<Affectation>()
                .HasOne(a => a.UserAffecting)
                .WithMany(u => u.Affectations)
                .HasForeignKey(a => a.IdUserAffecting)
                  .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Affectation>()
                .HasOne(a => a.EmpAffected)
                .WithMany(e => e.relations) // Assuming UserAffected is an Employe
                .HasForeignKey(a => a.IdEmpAffected)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Affectation>()
                .HasOne(a => a.Materiel)
                .WithMany(m => m.Affectations)
                .HasForeignKey(a => a.IdMat)
                  .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BonDentre>()
               .ToTable("BonDentre")
               .HasKey(b => b.idBonDentre);

            modelBuilder.Entity<BonDentre>()
                .HasMany(b => b.Materiels)
                .WithOne(m => m.BonDachat)
                .HasForeignKey(m => m.idBonDentree);

            // Fournisseur entity configuration
            modelBuilder.Entity<Fournisseur>()
                .ToTable("Fournisseur")
                .HasKey(f => f.CodeFiscal);

            // Employe entity configuration (adding primary key)
            modelBuilder.Entity<Employe>()
                .ToTable("Employe")
                .HasKey(e => e.IdEmp);

            // Ensure the base method is called
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<WebApplication8.Models.MatReseau> MatReseau { get; set; }

    }
}

