using CollegeManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
