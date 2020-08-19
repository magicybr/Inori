using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Inori.Domain.EventBus.Events;
using Microsoft.EntityFrameworkCore.Storage;

namespace Inori.Domain.EventBus.IntegrationEventLog.Services
{
    public class IntegrationEventLogService : IIntegrationEventLogService
    {
        private readonly DbConnection _connection;
        public IntegrationEventLogService(DbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            
        }
        public Task MarkEventAsFailedAsync(Guid eventId)
        {
            return Task.FromResult(true);
        }

        public Task MarkEventAsInProgressAsync(Guid eventId)
        {
            return Task.FromResult(true);
        }

        public Task MarkEventAsPublishedAsync(Guid eventId)
        {
            return Task.FromResult(true);
        }

        public Task<IEnumerable<IntegrationEventLogEntry>> RetrieveEventLogsPendingToPublishAsync(Guid transactionId)
        {
            throw new NotImplementedException();
        }

        public Task SaveEventAsync(IntegrationEvent @event, IDbContextTransaction tran)
        {
            return Task.FromResult(true);
        }
    }
}