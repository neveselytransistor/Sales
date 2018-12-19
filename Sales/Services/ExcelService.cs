using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sales.Models;

namespace Sales.Services
{
    public class ExcelService : IExcelService
    {
        private readonly IOrderService _orderService;
        private IHostingEnvironment _hostingEnvironment;

        public ExcelService(IOrderService orderService, IHostingEnvironment hostingEnvironment)
        {
            _orderService = orderService;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<MemoryStream> ExportReport(DateTime? dateStart, DateTime? dateEnd)
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = @"report.xlsx";
            var memory = new MemoryStream();

            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                var excelSheet = workbook.CreateSheet("Report");
                var row = excelSheet.CreateRow(0);

                row.CreateCell(0).SetCellValue("Номер заказа");
                row.CreateCell(1).SetCellValue("Дата заказа");
                row.CreateCell(2).SetCellValue("Артикул товара");
                row.CreateCell(3).SetCellValue("Название товара");
                row.CreateCell(4).SetCellValue("Количество");
                row.CreateCell(5).SetCellValue("Цена за ед.");
                row.CreateCell(6).SetCellValue("Общая стоимость");

                List<Order> orders;

                if (dateStart != null && dateEnd != null)
                {
                    orders = await _orderService.GetOrders(dateStart.Value, dateEnd.Value);
                }
                else
                {
                    orders = await _orderService.GetOrders();
                }

                int i = 0;
                foreach (var order in orders)
                {
                    int j = i;
                    foreach (var detail in order.OrderDetail)
                    {
                        var product = detail.Product;

                        row = excelSheet.CreateRow(j + 1);

                        row.CreateCell(0).SetCellValue(orders[i].ID);
                        row.CreateCell(1).SetCellValue(orders[i].OrderDate);
                        row.CreateCell(2).SetCellValue(product.ID);
                        row.CreateCell(3).SetCellValue(product.Name);
                        row.CreateCell(4).SetCellValue(order.OrderDetail.First(x => x.ProductID == product.ID).Quantity);
                        row.CreateCell(5).SetCellValue((double) product.UnitPrice);
                        row.CreateCell(6).SetCellType(CellType.Formula);
                        row.GetCell(6).SetCellFormula($"E{j+2}*F{j+2}");

                        j++;
                    }
                    i++;
                }

                workbook.Write(fs);
            }

            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;
            return memory;
        }
    }
}