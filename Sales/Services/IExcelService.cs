using System;
using System.IO;
using System.Threading.Tasks;

namespace Sales.Services
{
    public interface IExcelService
    {
        /// <summary>
        ///  Создает отчет по заказам за определенный период времени
        /// </summary>
        /// <param name="dateStart">Дата начала периода</param>
        /// <param name="dateEnd">Дата окончания периода</param>
        /// <returns></returns>
        Task<MemoryStream> ExportReport(DateTime? dateStart, DateTime? dateEnd);
    }
}