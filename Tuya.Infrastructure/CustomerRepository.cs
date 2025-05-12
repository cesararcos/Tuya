using Microsoft.EntityFrameworkCore;
using Tuya.Domain;
using Tuya.Domain.Entities;

namespace Tuya.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync() =>
            await _context.Customers.ToListAsync();

        public async Task<bool> SaveAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _context.Customers.FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
