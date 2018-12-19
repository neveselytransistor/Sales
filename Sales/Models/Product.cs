using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }
        
        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}