using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogicLayer.Entities;
using BusinessLogicLayer.Services;

namespace PresentationLayer.Controllers
{
    public class AdminController : ApiController
    {



        // Seller operation
       
        [Route("api/sellerList")]
        [HttpGet]
        public List<UserModel> Seller()
        {
            return UserService.SellerList();
        }








        [Route("api/seller/add")]
        [HttpPost]
        public void AddSeller(UserModel e)
        {
            UserService.Add(e);
        }

        [Route("api/seller/edit")]
        [HttpPost]
        public void EditSeller(UserModel e)
        {
            UserService.Edit(e);
        }

        [Route("api/seller/delete/{id}")]
        [HttpDelete]
        public void DeleteSeller(int id)
        {
            UserService.Delete(id);
        }



        // Customer operation
        [Route("api/customerList")]
        [HttpGet]
        public List<UserModel> Customer()
        {
            return UserService.CustomerList();
        }


        [Route("api/customer/add")]
        [HttpPost]

        public void AddCustomer(UserModel e)
        {
            UserService.Add(e);
        }

        [Route("api/customer/edit")]
        [HttpPost]
        public void EditCustomer(UserModel e)
        {
            UserService.Edit(e);
        }
        [Route("api/customer/delete/{id}")]
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            UserService.Delete(id);
        }


        // Delivery boy operations
        [Route("api/deliveryBoyList")]
        [HttpGet]
        public List<UserModel> DeliveryBoy()
        {
            return UserService.DeliveryBoyList();
        }
        [Route("api/deliveryBoy/add")]
        [HttpPost]

        public void AddDeliveryBoy(UserModel e)
        {
            UserService.Add(e);
        }
        [Route("api/deliveryBoy/edit")]
        [HttpPost]
        public void EditDeliveryBoy(UserModel e)
        {
            UserService.Edit(e);
        }
        [Route("api/deliveryBoy/delete/{id}")]
        [HttpDelete]
        public void DeleteDeliveryBoy(int id)
        {
            UserService.Delete(id);
        }


        // All user operation
        [HttpGet]
        [Route("api/user/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var st = UserService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, st);
        }


        // seller Product Operation 
        [Route("api/productList")]
        [HttpGet]
        public List<ProductModel> Products()
        {
            return ProductService.ProductList();
        }

        [Route("api/seller/products/{id}")]
        [HttpGet]
        public List<ProductModel> SellerProducts(int id)
        {
            return ProductService.SellerProducts(id);
        }

        // customer order operation

        [Route("api/orderList")]
        [HttpGet]
        public List<OrderModel> Orders()
        {
            return OrderService.OrderList();
        }

        [Route("api/customer/orders/{id}")]
        [HttpGet]
        public List<OrderModel> CustomerOrders(int id)
        {
            return OrderService.CustomerOrders(id);
        }

        // Delivery boys Deliveries operation
        [Route("api/deliveryList")]
        [HttpGet]
        public List<DeliveryModel> Deliveries()
        {
            return DeliveryService.DeliveryList();
        }

        [Route("api/deliveryBoy/deliveries/{id}")]
        [HttpGet]
        public List<DeliveryModel> DeliveryBoyDeliveries(int id)
        {
            return DeliveryService.DeliveryBoyDeliveries(id);
        }



        [Route("api/categoryList")]
        [HttpGet]
        public List<CategoryModel> Categories()
        {
            return CategoryService.CategoryList();
        }

        [Route("api/category/add")]
        [HttpPost]

        public void AddCategory(CategoryModel e)
        {
            CategoryService.Add(e);
        }
        [Route("api/category/edit")]
        [HttpPost]
        public void EditCategory(CategoryModel e)
        {
            CategoryService.Edit(e);
        }
        [Route("api/category/delete/{id}")]
        [HttpDelete]
        public void DeleteCategory(int id)
        {
            CategoryService.Delete(id);
        }


    }
}
