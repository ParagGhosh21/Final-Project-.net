using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities
{
    public class DeliveryModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string DeliveryBoyName { get; set; }
        public int DeliveryBoyId { get; set; }
        public string Status { get; set; }
        public string CustomerEmail { get; set; }
        public string DeliveryBoyEmail { get; set; }
    }
}
