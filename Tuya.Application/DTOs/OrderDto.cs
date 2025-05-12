using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuya.Application.DTOs
{
    public class OrderDto
    {
        public Guid CustomerId { get; set; }
        public List<OrderDetailDto> Details { get; set; } = new();
    }
}
