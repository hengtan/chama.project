using System;
using System.Collections.Generic;
using System.Text;

namespace Chama.Domain.Models
{
    public class CourseDetail
    {
        public string courseID { get; set; }
        public int Total { get; set; }
        public List<Student> EnrolledStudents { get; set; }
        public string CourseName { get; set; }
        public int MaxSize { get; set; }
        public Lecturer Leacuture { get; set; }
        public string MinAge { get; set; }
        public string MaxAge { get; set; }
        public string AgeAvg{ get; set; }
    }
}
