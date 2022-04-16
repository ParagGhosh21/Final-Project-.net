using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Details { get; set; }
        public string SellerName { get; set; }
        public int SellerId { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public string SellerEmail { get; set; }
    }
}
