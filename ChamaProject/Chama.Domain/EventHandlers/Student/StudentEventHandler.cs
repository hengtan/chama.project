using Chama.Domain.Events.Student;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Chama.Domain.EventHandlers.Student
{
    public class StudentEventHandler :
        INotificationHandler<StudentRegisteredEvent>,
        INotificationHandler<StudentRegisteredAsyncEvent>
    {
        public Task Handle(StudentRegisteredEvent message, CancellationToken cancellationToken)
        {
           return Task.CompletedTask;
        }

        public Task Handle(StudentRegisteredAsyncEvent message, CancellationToken cancellationToken)
        {
            //TODO ENVIAR EMAIL
            return Task.CompletedTask;
        }
    }
}


