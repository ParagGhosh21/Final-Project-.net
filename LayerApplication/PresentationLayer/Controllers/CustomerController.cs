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
    public class CustomerController : ApiController
    {
        [Route("api/order/update")]
        [HttpPost]
        public void EditOrder(OrderModel e)
        {
            OrderService.Edit(e);
        }
    }
}
