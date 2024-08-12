using FacultyServices.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyServices.Data.Context
{
    public class FacultyDbContext : DbContext
    {
        public FacultyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Faculty> Faculty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
