using System;
using Chama.Domain.Commands.Student;
using Chama.Domain.Core.Bus;
using Chama.Domain.Core.Notification;
using Chama.Domain.Events.Student;
using Chama.Domain.Interfaces;
using Chama.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Chama.Domain.CommandHandlers
{
    public class StudentCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMediatorHandler Bus;

        public StudentCommandHandler(IStudentRepository studentRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _studentRepository = studentRepository;
            Bus = bus;
        }

        public Task Handle(RegisterNewStudentCommand message, CancellationToken cancellationToken)
        {
            //check if the command
            if (!message.IsValid())
            {
                //sent notification if the commando is not accepted
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            //if the course it's full send a notification
            bool isCourseFull = _courseRepository.IsCourseFull(message.CourseId);

            if (isCourseFull)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The course has already been full."));
                return Task.CompletedTask;
            }

            var student = new Student(message.Id, message.Name, message.Age);

            _studentRepository.Add(student);

            //Save Student
            if (Commit())
            {
                Bus.RaiseEvent(new StudentRegisteredEvent(student.Id, student.Name, Convert.ToInt32(student.Age), student.CourseId));
            }

            return Task.CompletedTask;
        }

        //ASYNC
        public Task Handle(RegisterNewStudentAsyncCommand message, CancellationToken cancellationToken)
        {
            //check if the command
            if (!message.IsValid())
            {
                //sent notification if the commando is not accepted
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            //if the course it's full send a notification
            bool isCourseFull = _courseRepository.IsCourseFull(message.CourseId);

            if (isCourseFull)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The course has already been full."));
                return Task.CompletedTask;
            }

            var student = new Student(message.Id, message.Name, message.Age);

            _studentRepository.Add(student);

            //Save Student
            if (Commit())
            {
                Bus.RaiseEvent(new StudentRegisteredAsyncEvent(student.Id, student.Name, Convert.ToInt32(student.Age), student.CourseId));
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _studentRepository.Dispose();
        }
    }
}
