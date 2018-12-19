using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales.Models
{
    public class Order
    {
        public int ID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OrderDate { get; set; }
        
        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}