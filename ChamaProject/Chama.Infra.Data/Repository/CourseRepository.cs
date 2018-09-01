using Chama.Domain.Interfaces;
using Chama.Domain.Models;
using Chama.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Chama.Infra.Data.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ChamaContext context) : base(context)
        {
        }

        public bool IsCourseFull(int id)
        {
            var courseIsFull = false;
            var course = DbSet.AsNoTracking().FirstOrDefault(c => c.Id == ConvertToGuid.ToGuid(id));
            if (course.EnrolledStudents.Count >= course.MaxSize)
                courseIsFull = true;
            return courseIsFull;
        }
    }
}
