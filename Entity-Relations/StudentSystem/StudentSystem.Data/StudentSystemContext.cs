using Microsoft.EntityFrameworkCore;
using StudentSystem.Data.EntityConfiguration;
using StudentSystem.Models;

namespace StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        private static StudentSystemContext _instance;

        public DbSet<Student> Students { get; set; }
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<StudentCourse> StudentCourses { get; set; }
        //public DbSet<Resource> Resources { get; set; }
        //public DbSet<HomeworkSubmission> HomeworkSubmissions { get; set; }

        //private StudentSystemContext(DbContextOptions options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }

        public static StudentSystemContext CreateInstance()
        {
            if (_instance != null)
            {
                return _instance;
            }

            _instance = new StudentSystemContext();
            return _instance;
        }
    }
}