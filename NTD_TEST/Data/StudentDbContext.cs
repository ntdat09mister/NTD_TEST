using NTD_TEST.Models;
using System.Data.Entity;

namespace NTD_TEST.Data
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("student");
        }
    }
}
