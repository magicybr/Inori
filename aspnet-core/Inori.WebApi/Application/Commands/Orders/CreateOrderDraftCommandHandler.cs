using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inori.Domain.Models.Orders.OrderAggregate;
using Inori.WebApi.Extensions;
using Inori.WebApi.Services;
using MediatR;

namespace Inori.WebApi.Application.Commands
{
    public class CreateOrderDraftCommandHandler
        : IRequestHandler<CreateOrderDraftCommand, OrderDraftDTO>
    {
        private readonly IMediator _mediator;
        private readonly IIdentityService _identitySercie;

        public CreateOrderDraftCommandHandler(IMediator mediator, IIdentityService identityService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _identitySercie = identityService ?? throw new ArgumentNullException(nameof(identityService));

        }
        public Task<OrderDraftDTO> Handle(CreateOrderDraftCommand request, CancellationToken cancellationToken)
        {
            var order = Order.NewDraft();
            var orderItems = request.Items.Select(c => c.ToOrderItemDTO());
            foreach (var item in orderItems)
            {
                order.AddOrderItem(item.ProductId, item.ProductName, item.UnitPrice, item.Discount, item.PictureUrl, item.Units);
            }

            return Task.FromResult(OrderDraftDTO.FromOrder(order));
        }
    }

    public class OrderDraftDTO
    {
        public IEnumerable<OrderItemDTO> OrderItems { get; set; }
        public decimal Total { get; set; }
        public static OrderDraftDTO FromOrder(Order order)
        {
            return new OrderDraftDTO()
            {
                OrderItems = order.OrderItems.Select(c => new OrderItemDTO
                {
                    Discount = c.GetCurrentDiscount(),
                    ProductId = c.ProductId,
                    UnitPrice = c.GetUnitPrice(),
                    PictureUrl = c.GetPictureuri(),
                    Units = c.GetUnits(),
                    ProductName = c.GetOrderItemProductName()
                }),
                Total = order.GetTotal()
            };
        }
    }
}