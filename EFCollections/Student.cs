using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCollections
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public Classroom Classroom { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
