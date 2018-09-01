using Chama.Domain.Core.Commands;
using System;
using Chama.Domain.Models;

namespace Chama.Domain.Commands.Student
{
    public abstract class StudentCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public int CourseId { get; set; }

        public Lecturer Leacuture { get; set; }
    }
}
