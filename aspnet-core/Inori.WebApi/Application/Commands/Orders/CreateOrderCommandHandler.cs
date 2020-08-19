using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Inori.WebApi.Application.Commands
{
    public class CreateOrderCommandHandler
        : IRequestHandler<CreateOrderCommand, bool>
    {
        public Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}