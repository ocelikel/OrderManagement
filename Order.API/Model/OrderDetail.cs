using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Model
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
