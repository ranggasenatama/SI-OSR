using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIOSR.Migrations;
using SIOSR.Models;
using SIOSR.Models.App;

namespace SIOSR.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PenggalanganDana> PenggalanganDana { get; set; }
        public DbSet<Donasi> Donasi { get; set; }
        public DbSet<Anak> Anak { get; set; }
        public DbSet<Absensi> Absensi { get; set; }
        public DbSet<Materi> Materi { get; set; }
        public DbSet<Lomba> Lomba { get; set; }
        public DbSet<Umkm> Umkm { get; set; }
        public DbSet<Pembelian> Pembelian { get; set; }
        public DbSet<Staff> Staff { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            modelBuilder.Entity<Absensi> ()
                        .Property (p => p.CreatedAt)
                        .HasDefaultValueSql ("now()");
            modelBuilder.Entity<Lomba> ()
                        .Property (p => p.CreatedAt)
                        .HasDefaultValueSql ("now()");
            modelBuilder.Entity<PenggalanganDana> ()
                        .Property (p => p.CreatedAt)
                        .HasDefaultValueSql ("now()");
            modelBuilder.Entity<Donasi> ()
                        .Property (p => p.CreatedAt)
                        .HasDefaultValueSql ("now()");
            modelBuilder.Entity<Umkm> ()
                        .Property (p => p.CreatedAt)
                        .HasDefaultValueSql ("now()");
            modelBuilder.Entity<Materi> ()
                        .Property (p => p.CreatedAt)
                        .HasDefaultValueSql ("now()");
            modelBuilder.Entity<Pembelian> ()
                        .Property (p => p.CreatedAt)
                        .HasDefaultValueSql ("now()");
            modelBuilder.Entity<Staff> ()
                        .Property (p => p.CreatedAt)
                        .HasDefaultValueSql ("now()");
        }

        public override int SaveChanges () {
            OnBeforeSaveChanges ();
            return base.SaveChanges ();
        }

        public override Task<int> SaveChangesAsync (bool acceptAllChangesOnSuccess, CancellationToken cancellationToken=default (CancellationToken)) {
            OnBeforeSaveChanges ();
            return base.SaveChangesAsync (acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaveChanges () {
            var selectedEntityList = ChangeTracker.Entries ()
                                                  .Where (x => x.Entity is TrackableEntity
                                                               && (x.State == EntityState.Added
                                                                   || x.State == EntityState.Modified));
            Console.Out.WriteLine ("Apaini");
            Console.Out.WriteLine (selectedEntityList);
            foreach (var entity in selectedEntityList)
                ((TrackableEntity) entity.Entity).UpdatedAt = DateTime.UtcNow;
        }
    }
}
