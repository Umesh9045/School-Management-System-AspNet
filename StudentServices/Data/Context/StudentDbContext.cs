using Microsoft.EntityFrameworkCore;
using StudentServices.Data.Models;

namespace StudentServices.Data.Context
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Student> students { get; set; }
    }
}
