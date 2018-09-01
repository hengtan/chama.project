using AutoMapper;
using Chama.Application.Interfaces;
using Chama.Domain.Commands.Course;
using Chama.Domain.Core.Bus;
using Chama.Domain.Interfaces;
using Chama.Domain.Models;
using Chama.Infra.Data;
using Chama.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Chama.Application.Services
{
    public class CourseAsyncAppService : ICourseAsyncAppService
    {
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;
        private readonly ICourseAsyncRepository _courseRepository;
        
        public CourseAsyncAppService(IMediatorHandler bus,
            ICourseAsyncRepository courseRepository,
            IEventStoreRepository eventStoreRepository, IMapper mapper)
        {
            _bus = bus;
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task increaseCourseSizeAsync(int courseId)
        {
            var course = _courseRepository.GetById(ConvertToGuid.ToGuid(courseId));
            //SUM 1 THE PROP SIZE
            course.Result.MaxSize = course.Result.MaxSize + 1;
            var updateCommand = _mapper.Map<IncreaseCourseSizeCommand>(course);
            //UPDATE COURSE
            await _bus.SendCommand(updateCommand);
        }

        public async Task<Course> GetByIdAsync(Guid id)
        {
            var c = GetAllAsync();
            return c.Result.FirstOrDefault(p => p.Id == id);
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _courseRepository.GetAll();
            //CALL BUS AND CREATE A NEW COMMAND?
        }

        public async Task<IEnumerable<CourseDetail>> StudentsListDetail()
        {
            var courseDetails = new List<CourseDetail>();

            var allCourseList = await GetAllAsync();
            var courseList = allCourseList.ToList();

            //TODO REFACTOR THE MODEL COURSEDETAIL
            for (var i = 0; i < courseList.Count; i++)
            {
                //TODO REFACTOR
                var aux = "";
                courseDetails[i].courseID = courseList[i].Id.ToString();
                courseDetails[i].CourseName = courseList[i].CourseName;
                courseDetails[i].MaxSize = courseList[i].MaxSize;
                courseDetails[i].Leacuture = courseList[i].Leacuture;
                courseDetails[i].EnrolledStudents = courseList[i].EnrolledStudents;
                courseDetails[i].Total = courseList[i].EnrolledStudents.Count;
                aux = courseList[i].EnrolledStudents.Max().ToString();
                courseDetails[i].MaxAge = aux;
                aux = courseList[i].EnrolledStudents.Min().ToString();
                courseDetails[i].MinAge = aux;
                courseDetails[i].AgeAvg = courseList[i].EnrolledStudents.ToString();
            }

            return courseDetails;
        }
    }
}
