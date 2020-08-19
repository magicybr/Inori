using System;
using System.Collections.Generic;
using Inori.Domain.EventBus.Events;
using Inori.Domain.IntegrationEvents.Abstractions;
using static Inori.Domain.EventBus.InMemoryEventBubSubscriptionsManager;

namespace Inori.Domain.EventBus
{
    public interface IEventBusSubscriptionsManager
    {

        bool IsEmpty { get; }

        void Clear();

        event EventHandler<string> OnEventRemoved;

        void AddSubscription<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        void RemoveSubscription<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        bool HasSubscriptionForEvent<T>()
            where T : IntegrationEvent;

        bool HasSubscriptionForEvent(string eventName);

        Type GetEventTypeByName(string eventName);

        IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>()
            where T : IntegrationEvent;
            
        IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);

    }
}