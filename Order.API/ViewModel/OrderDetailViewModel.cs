using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.ViewModel
{
    public class OrderDetailViewModel
    {
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
