using BusinessLogicLayer.Entities;
using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PresentationLayer.Controllers
{
    public class SellerController : ApiController
    {
        [Route("api/product/add")]
        [HttpPost]

        public void AddProduct(ProductModel e)
        {
            ProductService.Add(e);
        }
        [Route("api/seller/{id}/products")]
        [HttpGet]
        public List<ProductModel> SellerProducts(int id)
        {
            return ProductService.SellerProducts(id);
        }
        [Route("api/product/edit")]
        [HttpPost]
        public void EditProduct(ProductModel e)
        {
            ProductService.Edit(e);
        }

        [Route("api/seller/orders/{id}")]
        [HttpGet]
        public List<OrderModel> CustomerOrders(int id)
        {
            return OrderService.CustomerOrders(id);
        }
    }
}
