using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Database;

namespace DataAccessLayer.Repos
{
    public class ProductRepo : IRepository<Product, int>
    {
        private ProjectEntities db;
        public ProductRepo(ProjectEntities db)
        {
            this.db = db;
        }
        public void Add(Product obj)
        {
            db.Products.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var orderDetailsTable = (from pt in db.OrderDetails
                                     where pt.ProductId == id
                                     select pt).ToList();
            foreach (var items in orderDetailsTable)
            {
                db.OrderDetails.Remove(items);
            }
            //delete from product Rating Table
            var productRatingTable = (from pt in db.ProductRatings
                                      where pt.ProductId == id
                                      select pt).ToList();
            foreach (var items in productRatingTable)
            {
                db.ProductRatings.Remove(items);
            }
            var productTable = (from st in db.Products
                                where st.Id == id
                                select st).FirstOrDefault();
            db.Products.Remove(productTable);
            db.SaveChanges();
        }

       

        public void Edit(Product obj)
        {
            var pd = db.Products.FirstOrDefault(em => em.Id == obj.Id);
            db.Entry(pd).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }

        public Product Get(int id)
        {
            return db.Products.FirstOrDefault(e => e.Id == id);
        }

        public List<Product> Get()
        {
            return db.Products.ToList();
        }

        public List<Product> GetByUserId(int id)
        {
            var sellerProducts = (from sp in db.Products
                where sp.SellerId == id
                select sp).ToList();
            return sellerProducts;
        }
    }
}
