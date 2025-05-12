using Microsoft.EntityFrameworkCore;
using Tuya.Domain;
using Tuya.Domain.Entities;

namespace Tuya.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.Include(o => o.OrderDetails).ToListAsync();
        }

        public async Task SaveAsync(Order order)
        {
            var exists = await _context.Orders.AnyAsync(o => o.Id == order.Id);
            if (!exists)
                _context.Orders.Add(order);
            else
                _context.Orders.Update(order);

            await _context.SaveChangesAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
