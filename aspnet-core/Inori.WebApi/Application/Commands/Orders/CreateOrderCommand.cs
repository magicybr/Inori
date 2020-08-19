using System.Runtime.Serialization;
using MediatR;

namespace Inori.WebApi.Application.Commands
{
    [DataContract]
    public class CreateOrderCommand : IRequest<bool>
    {
        [DataMember]
        public string City { get; private set; }
    }
    public class OrderItemDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        public int Units { get; set; }

        public string PictureUrl { get; set; }
    }
}