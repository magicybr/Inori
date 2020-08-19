using Inori.Domain.Models.Orders;
using Inori.Domain.Models.Orders.OrderAggregate;
using Xunit;
namespace Inori.UnitTests.Domain
{
    public class OrderAggregateTest
    {
        [Fact]
        public void Create_order_item_success()
        {
            var productId = 1;
            var productName = "FakeProductName";
            var unitPrice = 1;
            var discount = 1;
            var pictureUrl = "FakeUrl";
            var units = 5;

            var fakeOrderItem = new OrderItem(productId, productName, unitPrice, discount, pictureUrl, units);

            Assert.NotNull(fakeOrderItem);
        }
        [Fact]
        public void Invalid_number_of_units()
        {
            var productId = 1;
            var productName = "FakeProductName";
            var unitPrice = 1;
            var discount = 1;
            var pictureUrl = "FakeUrl";
            var units = -1;

            Assert.Throws<OrderingDomainException>(() => new OrderItem(productId, productName, unitPrice, discount, pictureUrl, units));
        }
        [Fact]
        public void Invalid_total_of_order_item_lower_than_discount_applied()
        {
            //Arrange    
            var productId = 1;
            var productName = "FakeProductName";
            var unitPrice = 12;
            var discount = 15;
            var pictureUrl = "FakeUrl";
            var units = 1;

            //Act - Assert
            Assert.Throws<OrderingDomainException>(() => new OrderItem(productId, productName, unitPrice, discount, pictureUrl, units));
        }
    }
}