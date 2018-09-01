using Chama.Domain.Core.Commands;
using Chama.Domain.Core.Events;
using System.Threading.Tasks;

namespace Chama.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
