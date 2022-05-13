using Education.Domain;
using Microsoft.EntityFrameworkCore;

namespace Education.Persistence
{
    public class EducationDbContext : DbContext
    {
        public EducationDbContext() { }
        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;database=EducationCQRS;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(c => c.Price)
                .HasPrecision(14,2);

            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = Guid.NewGuid(),
                Description = "Basic C# Course",
                Name = "C# course from zero to hero",
                CreationDate = DateTime.Now,
                PublishDate = DateTime.Now.AddYears(2),
                Price = 80
            });

            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = Guid.NewGuid(),
                Description = "Java Course",
                Name = "Advanced Java Course",
                CreationDate = DateTime.Now,
                PublishDate = DateTime.Now.AddYears(2),
                Price = 100
            });

            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = Guid.NewGuid(),
                Description = "Master in Unit Test with CQRS",
                Name = "Unit Tests in .NET 6",
                CreationDate = DateTime.Now,
                PublishDate = DateTime.Now.AddYears(2),
                Price = 150
            });
        }
    }
}