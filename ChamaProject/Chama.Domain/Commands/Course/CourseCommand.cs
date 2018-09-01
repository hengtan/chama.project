using System;
using Chama.Domain.Core.Commands;
using Chama.Domain.Core.Events;

namespace Chama.Domain.Commands.Course
{
    public abstract class CourseCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; set; }
    }
}
