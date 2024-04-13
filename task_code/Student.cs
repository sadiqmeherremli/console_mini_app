using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_code
{
    public class Student
    {
        public string Name { get; }
        public string Surname { get; }

        public Student(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
