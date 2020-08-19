using System.Threading;
using System.Threading.Tasks;
using Inori.Domain.EventBus.Events;

namespace Inori.Domain.IntegrationEvents.Abstractions
{
    public interface IIntegrationEventHandler<in TEvent> : IntegrationEventHandler
        where TEvent : IntegrationEvent
    {
        Task HandleAsync(TEvent @event, CancellationToken cancellation = default);
    }

    public interface IntegrationEventHandler
    {
        Task HandleAsync(IntegrationEvent @integrationEvent, CancellationToken cancellationToken = default);
        bool CanHandle(IntegrationEvent @event);
    }
}