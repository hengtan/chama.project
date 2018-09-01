using Chama.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chama.Application.Interfaces
{
    public interface IStudentAsyncAppService : IDisposable
    {
        Task RegisterAsync(Student student);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(Guid id);
    }
}
