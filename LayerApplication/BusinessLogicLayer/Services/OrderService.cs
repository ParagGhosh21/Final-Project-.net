using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Entities;
using DataAccessLayer;
using DataAccessLayer.Database;

namespace BusinessLogicLayer.Services
{
    public class OrderService
    {
        public static List<OrderModel> OrderList()
        {
            var config = new MapperConfiguration(c => { c.CreateMap<Order, OrderModel>(); });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<OrderModel>>(DataAccessFactory.OrderDataAccess().Get());
            return data;
        }
        public static List<OrderModel> CustomerOrders(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<OrderModel>>(DataAccessFactory.OrderDataAccess().GetByUserId(id));
            return data;
        }
        public static void Edit(OrderModel e)
        {
            var data = new Mapper(new MapperConfiguration(cfg =>
                cfg.CreateMap<OrderModel, Order>())).Map<Order>(e);
            DataAccessFactory.OrderDataAccess().Edit(data);
        }
    }
}
