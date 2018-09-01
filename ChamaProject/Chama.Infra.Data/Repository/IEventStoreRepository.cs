using Chama.Domain.Core.Events;
using System;
using System.Collections.Generic;

namespace Chama.Infra.Data.Repository
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
