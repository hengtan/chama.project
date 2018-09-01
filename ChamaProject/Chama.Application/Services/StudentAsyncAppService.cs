using AutoMapper;
using Chama.Application.Interfaces;
using Chama.Domain.Commands.Student;
using Chama.Domain.Core.Bus;
using Chama.Domain.Interfaces;
using Chama.Domain.Models;
using Chama.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chama.Application.Services
{
    class StudentAsyncAppService : IStudentAsyncAppService
    {
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;
        private readonly IStudentAsyncRepository _studentRepository;

        public StudentAsyncAppService(IMediatorHandler bus,
            IStudentAsyncRepository studentRepository,
            IEventStoreRepository eventStoreRepository, IMapper mapper)
        {
            _bus = bus;
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Register(Student student)
        {
            var registerCommand = _mapper.Map<RegisterNewStudentCommand>(student);
            _bus.SendCommand(registerCommand);
        }

        public async Task RegisterAsync(Student student)
        {
            var registerCommand = _mapper.Map<RegisterNewStudentCommand>(student);
            await _bus.SendCommand(registerCommand);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAll();
        }

        //TODO: FIGURE OUT ABOUT
        public async Task<Student> GetByIdAsync(Guid id)
        {
            return await _studentRepository.GetById(id);
        }
    }
}
