using Inori.WebApi.Application.Commands;
using Inori.WebApi.Application.Queries;
using Inori.WebApi.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Inori.WebApi.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IOrderQueries _orderQueries;
        private readonly IIdentityService _identityService;
        private readonly ILogger<OrdersController> _logger;
        public OrdersController(
            IMediator mediator,
            IOrderQueries orderQueries,
            IIdentityService identityService,
            ILogger<OrdersController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _orderQueries = orderQueries ?? throw new ArgumentNullException(nameof(orderQueries));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Route("draft")]
        [HttpPost]
        public async Task<ActionResult<OrderDraftDTO>> CreateOrderDraftFromBasketDataAsync([FromBody] CreateOrderDraftCommand createOrderDraftCommand)
        {
            _logger.LogInformation(
                "----- Sending command:{CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "",
                nameof(createOrderDraftCommand.BuyerId),
                createOrderDraftCommand.BuyerId,
                createOrderDraftCommand
            );

            return await _mediator.Send(createOrderDraftCommand);
        }

    }
}