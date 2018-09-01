using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chama.Domain.Models;

namespace Chama.Application.Interfaces
{
    public interface ICourseAsyncAppService : IDisposable
    {
        Task increaseCourseSizeAsync(int courseId);
        Task<Course> GetByIdAsync(Guid id);
        Task<IEnumerable<Course>> GetAllAsync();
        Task<IEnumerable<CourseDetail>> StudentsListDetail();
    }
}
