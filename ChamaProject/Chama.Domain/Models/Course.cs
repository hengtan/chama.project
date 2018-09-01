using Chama.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Chama.Domain.Models
{
    public class Course : Entity
    {
        public Course(Guid id, string courseName, Lecturer leacture, int maxSize,
            IReadOnlyCollection<Student> enrolledStudents)
        {
            Id = id;
            CourseName = courseName;
            Leacuture = leacture;
            MaxSize = maxSize;
            EnrolledStudents = new List<Student>();
        }

        protected Course() { }
        public List<Student> EnrolledStudents;
        public string CourseName { get; set; }
        public int MaxSize { get; set; }
        public Lecturer Leacuture { get; set; }
    }
}
