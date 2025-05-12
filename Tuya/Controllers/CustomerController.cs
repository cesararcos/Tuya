using Microsoft.AspNetCore.Mvc;
using Tuya.Application;
using Tuya.Application.DTOs;
using Tuya.Domain.Entities;

namespace Tuya.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Customer> customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto customerDto)
        {
            bool success = await _customerService.SaveAsync(customerDto);

            if (!success)
                return BadRequest("No se pudo guardar el producto. Verifica los datos ingresados.");

            return Ok("Producto creado exitosamente.");
        }
    }
}
