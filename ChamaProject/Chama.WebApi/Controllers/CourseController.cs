using System;
using Chama.Domain.Core.Bus;
using Chama.Domain.Core.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Chama.Application.Interfaces;
using Chama.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace Chama.WebApi.Controllers
{
    [Authorize]
    public class CourseController : ApiController
    {
        public CourseController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) :
            base(notifications, mediator)
        {
        }
        
        // POST: api/Course
        [HttpPost]
        [AllowAnonymous]
        [Route("course-management")]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Course/5
        [HttpPut]
        [AllowAnonymous]
        [Route("course/{id:guid}")]
        public void Put(Guid id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [AllowAnonymous]
        [Route("course/{id:guid}")]
        public void Delete(Guid id)
        {
        }

    }
}
