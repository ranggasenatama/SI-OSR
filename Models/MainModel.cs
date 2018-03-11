using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.NewDb.Models {

    public class MainContext : DbContext {

        public MainContext (DbContextOptions<MainContext> options) : base(options) {

        }

        public DbSet<PenggalanganDana> PDanas { get; set; }
        public DbSet<Lomba> Lombas { get; set; }
    }

    public class PenggalanganDana {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Lomba {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}