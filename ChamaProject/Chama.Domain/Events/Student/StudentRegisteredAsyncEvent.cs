using Chama.Domain.Core.Events;
using System;

namespace Chama.Domain.Events.Student
{
    public class StudentRegisteredAsyncEvent : Event
    {
        public StudentRegisteredAsyncEvent(Guid id, string name, int age, int courseId)
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
