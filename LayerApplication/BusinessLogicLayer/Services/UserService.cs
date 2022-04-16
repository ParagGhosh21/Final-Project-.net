using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Entities;
using DataAccessLayer;
using DataAccessLayer.Database;
using DataAccessLayer.Repos;

namespace BusinessLogicLayer.Services
{
    public class UserService
    {
        public static List<UserModel> SellerList()
        {
            var config = new MapperConfiguration(c => { c.CreateMap<User, UserModel>(); });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<UserModel>>(DataAccessFactory.UserDataAccess().Get());

            var seller = (from b in data
                where b.Role.Equals("Seller")
                select b).ToList();
            return seller;
        }

        public static List<UserModel> CustomerList()
        {
            var config = new MapperConfiguration(c => { c.CreateMap<User, UserModel>(); });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<UserModel>>(DataAccessFactory.UserDataAccess().Get());

            var customer = (from b in data
                where b.Role.Equals("Customer")
                select b).ToList();
            return customer;
        }

        public static List<UserModel> DeliveryBoyList()
        {
            var config = new MapperConfiguration(c => { c.CreateMap<User, UserModel>(); });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<UserModel>>(DataAccessFactory.UserDataAccess().Get());

            var deliveryBoy = (from b in data
                where b.Role.Equals("Delivery-Boy")
                select b).ToList();
            return deliveryBoy;
        }
        public static void Add(UserModel e)
        {
            var data = new Mapper(new MapperConfiguration(cfg => 
                cfg.CreateMap<UserModel, User>())).Map<User>(e);
                DataAccessFactory.UserDataAccess().Add(data);
        }
        public static void Edit(UserModel e)
        {
            var data = new Mapper(new MapperConfiguration(cfg => 
                cfg.CreateMap<UserModel, User>())).Map<User>(e);
                DataAccessFactory.UserDataAccess().Edit(data);
        }
        public static void Delete(int id)
        {
            DataAccessFactory.UserDataAccess().Delete(id);
        }
        public static UserModel Get(int id)
        {
            var st = DataAccessFactory.UserDataAccess().Get(id);
            return new UserModel()
            {
                Id = st.Id,
                Email = st.Email,
                Name = st.Name,
                PassWord = st.PassWord,
                Role = st.Role,
                Phone = st.Phone,
                Address = st.Address,
                Status = st.Status,
                Image = st.Image

            };
        }
        
    }
}
