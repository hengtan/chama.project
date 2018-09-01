using Chama.Domain.Interfaces;
using Chama.Infra.Data.Context;

namespace Chama.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChamaContext _context;

        public UnitOfWork(ChamaContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
