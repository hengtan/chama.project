using Chama.Domain.Interfaces;
using Chama.Domain.Models;
using Chama.Infra.Data.Context;

namespace Chama.Infra.Data.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ChamaContext context)
            : base(context)
        {

        }
    }
}
