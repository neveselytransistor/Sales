using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Sales.Models
{
    public class OrderDetail
    {
        public int ID { get; set; }
        
        public int OrderID { get; set; }
        
        public int ProductID { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }

        public short Quantity { get; set; }
    }
}