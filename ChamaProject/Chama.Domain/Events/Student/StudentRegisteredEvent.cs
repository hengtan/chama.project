using System;
using System.Collections.Generic;
using System.Text;
using Chama.Domain.Core.Events;

namespace Chama.Domain.Events.Student
{
    public class StudentRegisteredEvent : Event
    {
        public StudentRegisteredEvent(Guid id, string name, int age, int courseId)
        {
            Id = id;
            Name = name;
            Age = age;
            CourseId = courseId;
            AggregateId = id;
        }

        public Guid Id { get; set; }

        public string Name { get; private set; }

        public int  Age { get; private set; }

        public int CourseId{ get; private set; }
    }
}
