using Microsoft.EntityFrameworkCore;

namespace Laboratorio13.Models
{
    public class SchoolContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAB1504-22\\SQLEXPRESS; Initial Catalog=School; trustservercertificate=True; Integrated Security=True;");
        }
    }
}
