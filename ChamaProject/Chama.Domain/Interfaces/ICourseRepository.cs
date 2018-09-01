using System;
using Chama.Domain.Models;

namespace Chama.Domain.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        bool IsCourseFull(int id);
    }
}
