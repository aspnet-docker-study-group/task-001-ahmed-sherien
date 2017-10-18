using Microsoft.EntityFrameworkCore;
using Students.Api.Infrastructure.EntityConfiguration;
using Students.Api.Models;

namespace Students.Api.Infrastructure
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StudentEntityTypeConfiguration());
        }
    }
}
