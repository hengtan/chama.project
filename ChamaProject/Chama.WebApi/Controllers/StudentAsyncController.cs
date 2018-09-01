using Chama.Application.Interfaces;
using Chama.Domain.Core.Bus;
using Chama.Domain.Core.Notification;
using Chama.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chama.WebApi.Controllers
{
    public class StudentAsyncController : ApiController
    {
        private readonly IStudentAsyncAppService _studentAppService;
        private readonly ICourseAsyncAppService _courseAppService;

        public StudentAsyncController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
            : base(notifications, mediator)
        {
        }

        // POST: api/StudentAsync
        [HttpPost,
         Route("api/signup-student/async/")]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(student);
            }

            await _studentAppService.RegisterAsync(student);
            //INCREASE COURSE PROP SIZE
            await _courseAppService.increaseCourseSizeAsync(student.CourseId);

            return Response(student);
        }
    }
}
