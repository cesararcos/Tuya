using Tuya.Application.DTOs;
using Tuya.Domain;
using Tuya.Domain.Entities;

namespace Tuya.Application.DomainService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository repository)
        {
            _customerRepository = repository;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<bool> SaveAsync(CustomerDto customerDto)
        {
            if (string.IsNullOrWhiteSpace(customerDto.Name))
                return false;

            Customer customer = new()
            {
                Name = customerDto.Name?.Trim()
            };

            return await _customerRepository.SaveAsync(customer);
        }

    }
}
