using System;

namespace Chama.Domain.Models
{
    public class Student : Person
    {
        public Student(Guid id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        protected Student() { }

        public int Age { get; set; }

        public int CourseId { get; set; }
    }
}
