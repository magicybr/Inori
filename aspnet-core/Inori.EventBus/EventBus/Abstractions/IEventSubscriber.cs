using Inori.Domain.EventBus.Events;

namespace Inori.Domain.IntegrationEvents.Abstractions
{
    public interface IEventSubscriber
    {
        void Subscribe<TEvent, TEventHandler>()
           where TEvent : IntegrationEvent
           where TEventHandler : IIntegrationEventHandler<TEvent>;

        void Unsubscribe<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IIntegrationEventHandler<TEvent>;
    }
}