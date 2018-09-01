using Chama.Domain.Events.Course;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Chama.Domain.EventHandlers.Course
{
    public  class CourseEventHandler :
        INotificationHandler<IncreaseCourseSizeEvent>
    {
        public Task Handle(IncreaseCourseSizeEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
