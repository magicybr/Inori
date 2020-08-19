using System;
using Inori.Domain.EventBus;
using Inori.Domain.EventBus.Events;
using Inori.Domain.IntegrationEvents.Abstractions;
using Microsoft.Extensions.Logging;

namespace Inori.Domain.Infrastructure.Events
{
    public class InMemoryEventBus : IEventBus, IDisposable
    {
        private readonly IEventBusSubscriptionsManager _subsManager;
        private readonly ILogger<InMemoryEventBus> _logger;
        public InMemoryEventBus(
            IEventBusSubscriptionsManager subsManager,
            ILogger<InMemoryEventBus> _logger
            )
        {
            _subsManager = subsManager ?? new InMemoryEventBubSubscriptionsManager();
            _subsManager.OnEventRemoved += SubsManager_OnEventRemove;
        }

        private void SubsManager_OnEventRemove(object sender, string eventName)
        {

        }

        public void Publish(IntegrationEvent @event)
        {
            throw new System.NotImplementedException();
        }

        public void Subscribe<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IIntegrationEventHandler<TEvent>
        {
            throw new System.NotImplementedException();
        }

        public void Unsubscribe<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IIntegrationEventHandler<TEvent>
        {
            throw new System.NotImplementedException();
        }


        private bool disposedValue = false;

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _subsManager.Clear();
                    _subsManager.OnEventRemoved -= SubsManager_OnEventRemove;
                    _logger.LogInformation($"InMemoryEventBus has been Disposed.Hash Code:{this.GetHashCode()}");
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}