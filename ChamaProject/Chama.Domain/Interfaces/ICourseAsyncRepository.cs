using System.Collections.Generic;
using System.Threading.Tasks;
using Chama.Domain.Models;

namespace Chama.Domain.Interfaces
{
    public interface ICourseAsyncRepository : IRepositoryAsync<Course>
    {
        bool IsCourseFull(int id);

        Task<Course> CourseInformation(int courseId);

        Task<IEnumerable<Course>> GetAllInformations();
    }
}
