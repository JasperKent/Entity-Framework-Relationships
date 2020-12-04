using System.Collections.Generic;

namespace EFCollections
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public ICollection<Student> Students { get; set; }

        public Teacher Teacher { get; set; }
    }
}
