using Microsoft.EntityFrameworkCore;

namespace EFCollections
{
    public class TrainingContext : DbContext
    {
        public TrainingContext()
        {

        }

        public TrainingContext(DbContextOptions<TrainingContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasOne(c => c.Editor).WithMany(t => t.CoursesEditted);
            modelBuilder.Entity<Course>().HasOne(c => c.Author).WithMany(t => t.CoursesWritten);
        }

        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
