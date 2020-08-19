using System.Threading.Tasks;
using Inori.Domain.EventBus.Events;

namespace Inori.Domain.IntegrationEvents.Abstractions
{
    public interface IEventPublisher
    {
        void Publish(IntegrationEvent @event);
    }
}