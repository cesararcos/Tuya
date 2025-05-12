using Microsoft.AspNetCore.Mvc;
using Tuya.Application;
using Tuya.Application.DomainService;
using Tuya.Application.DTOs;
using Tuya.Domain.Entities;

namespace Tuya.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Order> orders = await _ordersService.GetAllAsync();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDto orderDto)
        {
            Guid id = await _ordersService.CreateOrderAsync(orderDto);
            return Ok(new { OrderId = id });
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            bool result = await _ordersService.CancelOrderAsync(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}
