using Chama.Domain.Core.Events;
using System;

namespace Chama.Domain.Events.Course
{
    public class IncreaseCourseSizeEvent : Event
    {
        public IncreaseCourseSizeEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
