using System.Threading.Tasks;

namespace Inori.Domain.IntegrationEvents.Abstractions
{
    public interface IDynamicIntegrationEventHandler
    {
         Task HandleAsync(dynamic eventData);
    }
}