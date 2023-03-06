using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Course
    {
        private readonly string title;
        private readonly List<Student> students;

        public Course( string title)
        {
            this.title = title;
            this.students = new List<Student>();
        }

        public IReadOnlyCollection<Student> Students => students.AsReadOnly();

        public void AddStudent( Student student )
        {
            students.Add( student );
        }

        public override string ToString()
        {
            return $"has assigned to the {this.title} course.";
        }

    }
}
