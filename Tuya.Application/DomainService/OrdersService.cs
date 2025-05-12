using Tuya.Application.DTOs;
using Tuya.Domain;
using Tuya.Domain.Entities;

namespace Tuya.Application.DomainService
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Guid> CreateOrderAsync(OrderDto orderDto)
        {
            if (orderDto == null || orderDto.Details == null || !orderDto.Details.Any())
                return Guid.Empty;

            Order order = new Order()
            {
                CustomerId = orderDto.CustomerId,
                CreatedAt = DateTime.UtcNow,
                State = true,
                OrderDetails = orderDto.Details.Select(d => new OrderDetail
                {
                    ProductName = d.ProductName,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice
                }).ToList()
            };

            await _orderRepository.SaveAsync(order);
            return order.Id;
        }

        public async Task<bool> CancelOrderAsync(Guid Id)
        {
            Order? order = await _orderRepository.GetByIdAsync(Id);
            if (order == null) return false;

            order.State = false;
            await _orderRepository.SaveAsync(order);
            return true;
        }
    }
}
