using Chama.Application.Interfaces;
using Chama.Domain.Core.Bus;
using Chama.Domain.Core.Notification;
using Chama.Infra.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chama.WebApi.Controllers
{
    [Authorize]
    public class CourseAsynceController : ApiController
    {
        private readonly ICourseAsyncAppService _courseAppService;

        public CourseAsynceController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator, ICourseAsyncAppService courseAppService) :
            base(notifications, mediator)
        {
            _courseAppService = courseAppService;
        }

        // GET: api/Course
        [HttpPost,
         Route("api/coursedetails-async/")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {

            return Ok(_courseAppService.StudentsListDetail());
        }

        // GET: api/Course/5
        [HttpGet]
        [Route("api/coursedetails-async/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _courseAppService.GetByIdAsync(ConvertToGuid.ToGuid(id));

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}
