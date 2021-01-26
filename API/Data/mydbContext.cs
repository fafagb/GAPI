using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GAPI.API.Data {
    public partial class MyDBContext : DbContext {


        public MyDBContext (DbContextOptions<MyDBContext> options) : base (options) { }

        public virtual DbSet<Test> Test { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) { }
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Test> (entity => {
               
            });
        }
    }
}