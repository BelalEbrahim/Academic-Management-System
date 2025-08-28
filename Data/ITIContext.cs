using CRUD_Operations.Models;
using CRUD_Operations.Test;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operations.Data
{
    public class ITIContext : DbContext
    {


        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        // Add a DbSet for Course
        public DbSet<Models.Course> Courses { get; set; }

        public ITIContext(DbContextOptions options) : base(options) { }

        public ITIContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server =.;Database=mvcst1; Integrated Security=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply unique constraint to the Email field in Student
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
