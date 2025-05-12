using Tuya.Domain.Entities;

namespace Tuya.Domain
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<bool> SaveAsync(Customer customer);
        Task<Customer?> GetByIdAsync(Guid id);
    }
}
