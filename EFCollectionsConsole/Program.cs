using EFCollections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCollectionsConsole
{
    class Program
    {
        static void CreateData(TrainingContext db)
        {
            Teacher t1 = new Teacher { Name = "Miss Anderson" };
            Teacher t2 = new Teacher { Name = "Miss Bingham" };

            Classroom r1 = new Classroom { Number = "R101" };
            Classroom r2 = new Classroom { Number = "R202" };

            Course c1 = new Course { Title = "Introduction to EF Core", Author = t1, Editor = t2 };
            Course c2 = new Course { Title = "Basic Car Maintenance", Author = t2, Editor = t1 };

            Student s1 = new Student { Name = "Jenny Jones", Classroom = r1 };
            Student s2 = new Student { Name = "Kenny Kent", Classroom = r1 };
            Student s3 = new Student { Name = "Lucy Locket", Classroom = r1 };
            Student s4 = new Student { Name = "Micky Most", Classroom = r2 };
            Student s5 = new Student { Name = "Nelly Norton", Classroom = r2 };
            Student s6 = new Student { Name = "Ozzy Osborne", Classroom = r2 };


            c1.Students = new Student[] { s1, s2, s3, s4 };
            c2.Students = new Student[] { s3, s4, s5, s6 };

            db.Add(c1);
            db.Add(c2);

            db.SaveChanges();
        }

        static void Main()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var options = new DbContextOptionsBuilder<TrainingContext>()
                .UseSqlServer(config.GetConnectionString("TrainingDB"))
                .Options;

            using var db = new TrainingContext(options);

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            CreateData(db);
        }
    }
}
