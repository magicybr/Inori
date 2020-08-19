using System.Collections.Generic;
using System.Threading.Tasks;
using Inori.WebApi.Application.Commands;
using Inori.WebApi.Application.Models;
using Inori.WebApi.Application.Queries;
using Inori.WebApi.Controllers;
using Inori.WebApi.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Inori.UnitTests.Application
{
    public class OrdersControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IOrderQueries> _orderQueriesMock;
        private readonly Mock<IIdentityService> _identityServiceMock;
        private readonly Mock<ILogger<OrdersController>> _loggerMock;
        public OrdersControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _orderQueriesMock = new Mock<IOrderQueries>();
            _identityServiceMock = new Mock<IIdentityService>();
            _loggerMock = new Mock<ILogger<OrdersController>>();
        }
        [Fact]
        public async Task Post_createOrderDraftFromBasketDataAsync_success()
        {


            var fakeOrderDraftCmd = new CreateOrderDraftCommand("1", new List<BasketItem>()
            {
                new BasketItem{
                    Id = "1",
                    ProductId = 1,
                    ProductName = "prod 1",
                    UnitPrice = 100,
                    OldUnitPrice = 120,
                    Quantity = 2,
                    PictureUrl = "1.jpg"
                },
                new BasketItem{
                    Id = "2",
                    ProductId = 2,
                    ProductName = "prod 2",
                    UnitPrice = 200,
                    OldUnitPrice = 220,
                    Quantity = 3,
                    PictureUrl = "2.jpg"
                }
            });

            // var ordersController = new OrdersController(
            //     _mediatorMock.Object,
            //     _orderQueriesMock.Object,
            //     _identityServiceMock.Object,
            //     _loggerMock.Object
            //     );

            // var actionResult = await ordersController.CreateOrderDraftFromBasketDataAsync(command);

            // Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
            // Assert.Equal((((ObjectResult)actionResult.Result).Value as OrderDraftDTO).Total, 0);

            var handler = new CreateOrderDraftCommandHandler(_mediatorMock.Object, _identityServiceMock.Object);
            var cltToken = new System.Threading.CancellationToken();
            var result = await handler.Handle(fakeOrderDraftCmd, cltToken);

            Assert.Equal(800, result.Total);
            // _mediatorMock.Verify(x => x.Send(It.IsAny<IRequest<CreateOrderCommand>>(), default(System.Threading.CancellationToken)), Times.Once());
            // _mediatorMock.Verify(x => x.Send(It.IsAny<IRequest<bool>>(), default(System.Threading.CancellationToken)), Times.Once());
        }
    }
}