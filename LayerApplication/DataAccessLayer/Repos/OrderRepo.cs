using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Database;

namespace DataAccessLayer.Repos
{
    internal class OrderRepo : IRepository<Order, int>
    {
        private ProjectEntities db;
        public OrderRepo(ProjectEntities db)
        {
            this.db = db;
        }
        public void Add(Order obj)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> Get()
        {
            return db.Orders.ToList();
        }

        public void Edit(Order obj)
        {
            var ct = db.Orders.FirstOrDefault(em => em.Id == obj.Id);
            db.Entry(ct).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetByUserId(int id)
        {
            var customerOrders = (from sp in db.Orders
                where sp.CustomerId == id
                select sp).ToList();
            return customerOrders;
        }
    }
}
