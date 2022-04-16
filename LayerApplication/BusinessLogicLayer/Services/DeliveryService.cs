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
    public class DeliveryService
    {
        public static List<DeliveryModel> DeliveryList()
        {
            var config = new MapperConfiguration(c => { c.CreateMap<Delivery, DeliveryModel>(); });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<DeliveryModel>>(DataAccessFactory.DeliveryDataAccess().Get());
            return data;
        }
        public static List<DeliveryModel> DeliveryBoyDeliveries(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Delivery, DeliveryModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<DeliveryModel>>(DataAccessFactory.DeliveryDataAccess().GetByUserId(id));
            return data;
        }
    }
}
