using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLabo3.Model
{
    public static class AllStudents
    {
        public static IEnumerable<Student> Students { get; set; }
        public static IEnumerable<Student> GetAllStudents()
        {
            return Students = new List<Student>
            {
                new Student("Louis", 22),
                new Student("Brieuc", 23),
                new Student("Deblau", 23)
            };
        }
    }
}
