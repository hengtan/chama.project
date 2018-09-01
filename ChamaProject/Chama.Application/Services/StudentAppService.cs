using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class StudentAppService : IStudentAppService
    {
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public StudentAppService(IMediatorHandler bus,
            IStudentRepository studentRepository,
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

        public Task RegisterAsync(Student student)
        {
            return null;
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentRepository.GetAll().ProjectTo<Student>();
        }

        public Student GetById(Guid id)
        {
            return _mapper.Map<Student>(_studentRepository.GetById(id));
        }
    }
}
