using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sales.Models;

namespace Sales.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// Получает все заказы
        /// </summary>
        /// <returns></returns>
        Task<List<Order>> GetOrders();

        /// <summary>
        /// Получает заказы за определенный период времени
        /// </summary>
        /// <param name="dateFrom">Дата начала периода</param>
        /// <param name="dateEnd">Дата окончания периода</param>
        /// <returns></returns>
        Task<List<Order>> GetOrders(DateTime dateFrom, DateTime dateEnd);
    }
}