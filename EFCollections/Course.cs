using System.Collections.Generic;

namespace EFCollections
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Student> Students { get; set; }

        public Teacher Author { get; set; }
        public Teacher Editor { get; set; }

    }
}
