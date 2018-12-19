using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sales.Models;

namespace Sales.Repositories
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Получает все заказы
        /// </summary>
        /// <returns></returns>
        Task<List<Order>> GetAsync( );

        /// <summary>
        /// Получает заказы за определенный период времени
        /// </summary>
        /// <param name="periodStart">Дата начала периода</param>
        /// <param name="periodEnd">Дата окончания периода</param>
        /// <returns></returns>
        Task<List<Order>> GetAsync(DateTime periodStart, DateTime periodEnd);
    }
}