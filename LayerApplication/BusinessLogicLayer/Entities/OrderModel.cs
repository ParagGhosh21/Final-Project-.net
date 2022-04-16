using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public int TotalPrice { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string SellerEmail { get; set; }
        public string CustomerEmail { get; set; }
    }
}
