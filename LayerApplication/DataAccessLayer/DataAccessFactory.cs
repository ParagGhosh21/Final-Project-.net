using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Database;
using DataAccessLayer.Repos;

namespace DataAccessLayer
{
    public class DataAccessFactory
    {
        static ProjectEntities db = new ProjectEntities();
        public static IRepository<User, int> UserDataAccess()
        {
            return new UserRepo(db);
        }
       public static IRepository<Product, int> ProductDataAccess()
        {
            return new ProductRepo(db);
        }
       public static IRepository<Order, int> OrderDataAccess()
       {
           return new OrderRepo(db);
       }

       public static IRepository<Delivery, int> DeliveryDataAccess()
       {
           return new DeliveryRepo(db);
       }
       public static IRepository<Category, int> CategoryDataAccess()
       {
           return new CategoryRepo(db);
       }
       
    }
}
