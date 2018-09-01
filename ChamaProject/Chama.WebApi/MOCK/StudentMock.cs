using Chama.Domain.Models;
using System;

namespace Chama.WebApi.MOCK
{
    public class StudentMock
    {
        public Student CreateOneStudend()
        {
            return new Student(Guid.NewGuid(), "Ana", 15 );
        }
    }
}
