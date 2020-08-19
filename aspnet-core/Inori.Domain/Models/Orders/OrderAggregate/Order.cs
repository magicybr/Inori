using System;
using System.Collections.Generic;
using System.Linq;
using Inori.Domain.Models.Orders.Events;
using Inori.Domain.SeedWork;

namespace Inori.Domain.Models.Orders.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        private DateTime _orderDate;

        public Address Address { get; private set; }

        public int? GetBuyerId => _buyerId;

        private int? _buyerId;

        public OrderStatus OrderStatus { get; private set; }

        private int _orderStatusId;

        private string _description;

        private bool _isDraft;

        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        private int? _paymentMethodId;

        public static Order NewDraft()
        {
            var order = new Order();
            order._isDraft = true;
            return order;
        }

        protected Order()
        {
            _orderItems = new List<OrderItem>();
            _isDraft = false;
        }

        public Order(
            string userId,
            string userName,
            Address address,
            int cardTypeId,
            string cardnumber,
            string cardSecurityNumber,
            string cardHolderName,
            DateTime cardExpiration,
            int? buyerId = null,
            int? paymentMethodId = null) : this()
        {
            _buyerId = buyerId;
            _paymentMethodId = paymentMethodId;
            _orderDate = DateTime.UtcNow;
            Address = address;
        }

        public void AddOrderItem(int productId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units = 1)
        {
            var existingOrderForProduct = _orderItems.Where(c => c.ProductId == productId).SingleOrDefault();

            if (existingOrderForProduct != null)
            {
                if (discount > existingOrderForProduct.GetCurrentDiscount())
                    existingOrderForProduct.SetNewDiscount(discount);

                existingOrderForProduct.AddUnits(units);
            }
            else
            {
                var orderItem = new OrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
                _orderItems.Add(orderItem);
            }
        }

        private void AddOrderStartedDomainEvent(
            string userId, string userName, int cardTypeId, string cardNumber,
            string cardSecurityNumber, string cardHolderName, DateTime cardExpiration)
        {
            var orderStartedDomainEvent = new OrderStartedDomainEvent(
                this, userId, userName, cardTypeId, cardNumber,
                cardSecurityNumber, cardHolderName, cardExpiration);

            this.AddDomainEvent(orderStartedDomainEvent);
        }

        public decimal GetTotal()
        {
            return _orderItems.Sum(o => o.GetUnits() * o.GetUnitPrice());
        }
    }
}