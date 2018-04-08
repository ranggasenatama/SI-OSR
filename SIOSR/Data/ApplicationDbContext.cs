using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
