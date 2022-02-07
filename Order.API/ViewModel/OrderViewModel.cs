using Order.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.ViewModel
{
    public class OrderViewModel
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public List<OrderDetailViewModel> OrderDetailViewModels { get; set; }
    }
}
