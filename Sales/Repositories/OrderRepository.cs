using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales.Models;

namespace Sales.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAsync()
        {
            return await _context.Order.Include(order => order.OrderDetail)
                                 .ThenInclude(detail => detail.Product)
                                 .ToListAsync();
        }

        public async Task<List<Order>> GetAsync(DateTime periodStart, DateTime periodEnd)
        {
            return await _context.Order.Where(x => x.OrderDate >= periodStart && x.OrderDate <= periodEnd)
                                 .Include(order => order.OrderDetail)
                                 .ThenInclude(detail => detail.Product)
                                 .ToListAsync();
        }
    }
}