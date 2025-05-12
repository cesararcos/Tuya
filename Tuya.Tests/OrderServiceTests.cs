using Moq;
using Tuya.Application.DomainService;
using Tuya.Application.DTOs;
using Tuya.Domain;
using Tuya.Domain.Entities;

namespace Tuya.Tests
{
    public class OrderServiceTests
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepo = new();
        private readonly Mock<IOrderRepository> _mockOrderRepo = new();
        private readonly OrdersService _orderService;

        public OrderServiceTests()
        {
            _orderService = new OrdersService(_mockOrderRepo.Object, _mockCustomerRepo.Object);
        }

        [Fact]
        public async Task CreateOrderAsync_ShouldReturnTrue_WhenOrderIsValid()
        {
            // Arrange
            var customer = new Customer { Id = Guid.NewGuid() };
            var orderDetails = new List<OrderDetail>
            {
                new OrderDetail { ProductName = "Test", Quantity = 2, UnitPrice = 10 }
            };

            OrderDto orderDto = new OrderDto()
            {
                CustomerId = customer.Id,
                Details = orderDetails.Select(d => new OrderDetailDto
                {
                    ProductName = d.ProductName,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice
                }).ToList()
            };

            _mockOrderRepo.Setup(r => r.SaveAsync(It.IsAny<Order>())).Returns(Task.CompletedTask);

            // Act
            var result = await _orderService.CreateOrderAsync(orderDto);

            // Assert
            Assert.NotEqual(Guid.Empty, result);
            _mockOrderRepo.Verify(r => r.SaveAsync(It.IsAny<Order>()), Times.Once);
        }
    }
}
