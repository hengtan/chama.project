using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chama.Domain.Models;

namespace Chama.Application.Interfaces
{
    public interface ICourseAppService : IDisposable
    {
        void increaseCourseSize(int courseId);
    }
}
