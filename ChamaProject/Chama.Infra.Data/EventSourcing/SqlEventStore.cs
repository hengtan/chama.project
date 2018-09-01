using System;
using System.Collections.Generic;
using System.Text;
using Chama.Domain.Core.Events;
using Chama.Infra.Data.Repository;
using Newtonsoft.Json;

namespace Chama.Infra.Data.EventSourcing
{
    public class SqlEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData
            );

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
