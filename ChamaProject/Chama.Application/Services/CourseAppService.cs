using AutoMapper;
using AutoMapper.QueryableExtensions;
using Chama.Application.Interfaces;
using Chama.Domain.Commands.Course;
using Chama.Domain.Core.Bus;
using Chama.Domain.Interfaces;
using Chama.Domain.Models;
using Chama.Infra.Data;
using Chama.Infra.Data.Repository;
using Chama.Infra.Data.Util.Exceptions;
using System;
using System.Collections.Generic;

namespace Chama.Application.Services
{
    public class CourseAppService : ICourseAppService
    {
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly IEventStoreRepository _eventStoreRepository;

        public CourseAppService(IMediatorHandler bus,
            ICourseRepository courseRepository,
            IEventStoreRepository eventStoreRepository, IMapper mapper)
        {
            _bus = bus;
            _mapper = mapper;
            _courseRepository = courseRepository;
            _eventStoreRepository = eventStoreRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void increaseCourseSize(int courseId)
        {
            //GET THE COURSE BY ID
            var course = _courseRepository.GetById(ConvertToGuid.ToGuid(courseId));
            //SUM 1 THE PROP SIZE
            course.MaxSize = course.MaxSize + 1;
            var updateCommand = _mapper.Map<IncreaseCourseSizeCommand>(course);
            //UPDATE COURSE
            try
            {
                _bus.SendCommand(updateCommand);
            }
            catch (ExceptionIncreaseCourseSize ex)
            {
                throw new ExceptionIncreaseCourseSize(ex.Message);
            }
        }
        public IEnumerable<Course> GetAll()
        {
            return _courseRepository.GetAll().ProjectTo<Course>();
  
        }

        public Course GetById(Guid id)
        {
            return _mapper.Map<Course>(_courseRepository.GetById(id));
        }

        //TODO
        //public void Register(Course obj)
        //{
        //    var registerCommand = _mapper.Map<RegisterNewCourseCommand>(obj);
        //    Bus.SendCommand(registerCommand);
        //}

        //public void Update(Course obj)
        //{
        //    var updateCommand = _mapper.Map<UpdateCourseCommand>(obj);
        //    Bus.SendCommand(updateCommand);
        //}


        //public void Remove(Guid id)
        //{
        //    var removeCommand = new RemoveCourseCommand(id);
        //    Bus.SendCommand(removeCommand);
        //}
    }
}
