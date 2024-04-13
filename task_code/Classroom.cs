using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCode;

namespace task_code
{
    public class Classroom
    {
        public string Name { get; }
        public ClassroomType Type { get; }
        public Student[] Students { get; }
        private int studentCount;

        public Classroom(string name, ClassroomType type)
        {
            Name = name;
            Type = type;
            Students = new Student[100];
        }

        public void AddStudent(Student student)
        {
            if (studentCount >= (Type == ClassroomType.Backend ? 20 : 15))
            {
                Console.WriteLine("Sinif doludur");
                return;
            }

            Students[studentCount++] = student;
        }
    }


}
