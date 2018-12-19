
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sales.Services;

namespace Sales.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        private readonly IExcelService _excelService;

        public OrderController(IOrderService orderService, IExcelService excelService)
        {
            _orderService = orderService;
            _excelService = excelService;
        }

        [HttpGet]
        public async Task<ViewResult> List()
        {
            var orders = await _orderService.GetOrders();
            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> ToExcel(DateTime dateFrom, DateTime dateTo)
        {
            var sFileName = @"report.xlsx";
            var stream = await _excelService.ExportReport(dateFrom, dateTo);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }
    }
}