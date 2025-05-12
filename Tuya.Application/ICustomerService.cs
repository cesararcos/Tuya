using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuya.Application.DTOs;
using Tuya.Domain.Entities;

namespace Tuya.Application
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<bool> SaveAsync(CustomerDto customerDto);
    }
}
