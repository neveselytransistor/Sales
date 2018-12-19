using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sales.Models;
using Sales.Repositories;

namespace Sales.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository contactRepository)
        {
            _orderRepository = contactRepository;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _orderRepository.GetAsync();
        }

        public async Task<List<Order>> GetOrders(DateTime dateFrom, DateTime dateEnd)
        {
            return await _orderRepository.GetAsync(dateFrom, dateEnd);
        }
    }
}