using Chama.Application.Interfaces;
using Chama.Application.Services;
using Chama.Domain.CommandHandlers;
using Chama.Domain.Commands.Student;
using Chama.Domain.Core.Bus;
using Chama.Domain.Core.Notification;
using Chama.Domain.Core.Notifications;
using Chama.Domain.EventHandlers.Student;
using Chama.Domain.Events.Student;
using Chama.Domain.Interfaces;
using Chama.Infra.CrossCutting.Bus;
using Chama.Infra.Data.Context;
using Chama.Infra.Data.Repository;
using Chama.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Chama.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //Infra-Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Application
            services.AddScoped<IStudentAppService, StudentAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<StudentRegisteredEvent>, StudentEventHandler>();
            
            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewStudentCommand>, StudentCommandHandler>();

            // Infra - Data
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ChamaContext>();
        }
    }
}
