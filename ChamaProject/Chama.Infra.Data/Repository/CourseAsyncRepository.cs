using Chama.Domain.Interfaces;
using Chama.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chama.Infra.Data.Repository
{
    public class CourseAsyncRepository : RepositoryAsync<Course>, ICourseAsyncRepository
    {
        public bool IsCourseFull(int id)
        {
            var courseIsFull = false;
            var course = DbSet.AsNoTracking().FirstOrDefault(c => c.Id == ConvertToGuid.ToGuid(id));
            if (course.EnrolledStudents.Count >= course.MaxSize)
                courseIsFull = true;
            return courseIsFull;
        }

        public async Task<Course> CourseInformation(int courseId)
        {
            return await DbSet.
                Where(c => c.Id.Equals(courseId))
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Course>> GetAllInformations()
        {
            return await DbSet.ToListAsync();
        }
    }
}
