using Chama.Application.Interfaces;
using Chama.Domain.Core.Bus;
using Chama.Domain.Core.Notification;
using Chama.Domain.Models;
using Chama.WebApi.MOCK;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;

namespace Chama.WebApi.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IStudentAppService _studentAppService;
        private readonly ICourseAppService _courseAppService;
        private readonly ILogger _logger;

        public StudentController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IStudentAppService studentAppService, ILogger logger) :
            base(notifications, mediator)
        {
            _studentAppService = studentAppService;
            _logger = logger;
        }

        // GET: api/Student
        [HttpPost,
         Route("api/student/")]
        public IActionResult Get()
        {
            return Response(_studentAppService.GetAll());
        }
        [HttpPost,
         Route("api/student/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var customerViewModel = _studentAppService.GetById(id);
            return Response(customerViewModel);

            //MOCK CREATED TO TEST
            //return Response(new StudentMock().CreateOneStudend());
        }

        // POST: api/Student
        [HttpPost,
         Route("api/signup-student/")]
        public IActionResult Post([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return Response($"The student: {student.Name} cann't be created.");
            }

            _studentAppService.Register(student);
            //INCREASE COURSE PROP SIZE
            _courseAppService.increaseCourseSize(student.CourseId);

            if (IsValidOperation()) { _logger.LogInformation($"Created student: {student.Name} "); }
                return Ok($"The student: {student.Name} has been created.");
        }
    }
}
