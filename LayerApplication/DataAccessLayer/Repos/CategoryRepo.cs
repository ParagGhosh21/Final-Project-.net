using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Database;

namespace DataAccessLayer.Repos
{
    public class CategoryRepo : IRepository<Category, int>
    {
        private ProjectEntities db;
        public CategoryRepo(ProjectEntities db)
        {
            this.db = db;
        }
        public void Add(Category obj)
        {
            db.Categorys.Add(obj);
            db.SaveChanges();
        }

        public Category Get(int id)
        {
            return db.Categorys.FirstOrDefault(e => e.Id == id);
        }

        public List<Category> Get()
        {
            return db.Categorys.ToList();
        }

        public void Edit(Category obj)
        {
            var ct = db.Categorys.FirstOrDefault(em => em.Id == obj.Id);
            db.Entry(ct).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var ct = db.Categorys.FirstOrDefault(e => e.Id == id);

            var productTable = (from pt in db.Products
                where pt.CategoryId == ct.Id
                select pt).ToList();
            foreach (var items in productTable)
            {
                db.Products.Remove(items);
            }

            var categoryTable = (from cct in db.Categorys
                where cct.Id == id
                select ct).FirstOrDefault();
            db.Categorys.Remove(categoryTable);
            db.SaveChanges();
        }

        public List<Category> GetByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
