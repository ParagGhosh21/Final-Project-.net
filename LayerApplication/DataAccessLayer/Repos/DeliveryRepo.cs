using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Database;

namespace DataAccessLayer.Repos
{
    public class DeliveryRepo : IRepository<Delivery, int>
    {
        private ProjectEntities db;
        public DeliveryRepo(ProjectEntities db)
        {
            this.db = db;
        }
        public void Add(Delivery obj)
        {
            throw new NotImplementedException();
        }

        public Delivery Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Delivery> Get()
        {
            return db.Deliverys.ToList();
        }

        public void Edit(Delivery obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Delivery> GetByUserId(int id)
        {
            var deliveryBoyDeliveries = (from sp in db.Deliverys
                where sp.DeliveryBoyId == id
                select sp).ToList();
            return deliveryBoyDeliveries;
        }
    }
}
