using Chama.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chama.Application.Interfaces
{
    public interface IStudentAppService : IDisposable
    {
        void Register(Student student);
        Task RegisterAsync(Student student);
        IEnumerable<Student> GetAll();
        Student GetById(Guid id);
    }
}
