using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Database;

namespace DataAccessLayer.Repos
{
    public class UserRepo : IRepository<User, int>
    {
        private ProjectEntities db;
        public UserRepo(ProjectEntities db)
        {
            this.db = db;
        }
        public void Add(User obj)
        {

            var unique = (from e in db.Users
                where e.Email.Equals(obj.Email)
                select e).FirstOrDefault();
            if (unique != null)
            {

            }
            else
            {
                if (obj.Role.Equals("Seller"))
                {
                    var s = (from e in db.Sellers
                        where e.Email.Equals(obj.Email)
                        select e).FirstOrDefault();
                    if (s != null)
                    {
                        // error message show
                    }
                    else
                    {
                        var seller = new Seller();
                        seller.UserId = obj.Id;
                        seller.Email = obj.Email;
                        seller.Name = obj.Name;
                        seller.Address = obj.Address;
                        seller.Phone = obj.Phone;
                        seller.Status = "Pending";
                        seller.PassWord = obj.PassWord;

                        db.Sellers.Add(seller);
                        db.Users.Add(obj);
                        db.SaveChanges();
                    }
                }
                else if (obj.Role.Equals("Customer"))
                {
                    var s = (from e in db.Customers
                        where e.Email.Equals(obj.Email)
                        select e).FirstOrDefault();
                    if (s != null)
                    {
                        // error message show
                    }
                    else
                    {
                        var customer = new Customer();
                        customer.UserId = obj.Id;
                        customer.Email = obj.Email;
                        customer.Name = obj.Name;
                        customer.Address = obj.Address;
                        customer.Phone = obj.Phone;
                        customer.Status = "Approved";
                        customer.PassWord = obj.PassWord;

                        db.Customers.Add(customer);
                        db.Users.Add(obj);
                        db.SaveChanges();
                    }
                }
                else if (obj.Role.Equals("Delivery-Boy"))
                {
                    var s = (from e in db.Delivery_Boys
                        where e.Email.Equals(obj.Email)
                        select e).FirstOrDefault();
                    if (s != null)
                    {

                    }
                    else
                    {
                        var deliveryBoy = new Delivery_Boys();
                        deliveryBoy.UserId = obj.Id;
                        deliveryBoy.Email = obj.Email;
                        deliveryBoy.Name = obj.Name;
                        deliveryBoy.Address = obj.Address;
                        deliveryBoy.Phone = obj.Phone;
                        deliveryBoy.Status = "Pending";
                        deliveryBoy.PassWord = obj.PassWord;

                        db.Delivery_Boys.Add(deliveryBoy);
                        db.Users.Add(obj);
                        db.SaveChanges();
                    }
                }
            }
        }

        public void Edit(User obj)
        {
            var e = db.Users.FirstOrDefault(en => en.Id == obj.Id);
            db.Entry(e).CurrentValues.SetValues(obj);
            db.SaveChanges();

            if (obj.Role.Equals("Seller"))
            {
                var sellerTable = (from st in db.Sellers
                    where st.UserId.Equals(obj.Id)
                    select st).FirstOrDefault();

                sellerTable.Status = obj.Status;
                sellerTable.Name = obj.Name;
                sellerTable.Address = obj.Address;
                sellerTable.Phone = obj.Phone;
                sellerTable.PassWord = obj.PassWord;
                db.SaveChanges();
            }
            else if (obj.Role.Equals("Customer"))
            {
                var customerTable = (from st in db.Customers
                    where st.UserId.Equals(obj.Id)
                    select st).FirstOrDefault();

                customerTable.Status = obj.Status;
                customerTable.Name = obj.Name;
                customerTable.Address = obj.Address;
                customerTable.Phone = obj.Phone;
                customerTable.PassWord = obj.PassWord;
                db.SaveChanges();
            }
            else if (obj.Role.Equals("Delivery-Boy"))
            {
                var deliveryBoyTable = (from st in db.Delivery_Boys
                    where st.UserId.Equals(obj.Id)
                    select st).FirstOrDefault();

                deliveryBoyTable.Status = obj.Status;
                deliveryBoyTable.Name = obj.Name;
                deliveryBoyTable.Address = obj.Address;
                deliveryBoyTable.Phone = obj.Phone;
                deliveryBoyTable.PassWord = obj.PassWord;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var user = db.Users.FirstOrDefault(en => en.Id == id);

            if (user.Role.Equals("Seller"))
            {

                // Seller Order Delete
                var orderDetailTable = (from od in db.OrderDetails
                    where od.SellerId == user.Id
                    select od).ToList();

                foreach (var items in orderDetailTable)
                { 
                    db.OrderDetails.Remove(items);
                }

                // Product Delete
                var productTable = (from pt in db.Products
                    where pt.SellerId == user.Id
                    select pt).ToList();
                foreach (var items in productTable)
                {
                    // Product Rating Delete
                    var ratingTable = (from pt in db.ProductRatings
                        where pt.ProductId == items.Id
                        select pt).ToList();

                    foreach (var i in ratingTable)
                    {
                        db.ProductRatings.Remove(i);
                    }
                    db.Products.Remove(items);
                }
                
                // Seller Delete From Seller Table
                var sellerTable = (from st in db.Sellers
                    where st.UserId == user.Id
                    select st).FirstOrDefault();
                db.Sellers.Remove(sellerTable);

                // Seller Delete from User Table
                db.Users.Remove(user);
                db.SaveChanges();

            }
            else if (user.Role.Equals("Customer"))
            {

                // Customer single Order Details  Delete
                 var orderDetailsTable = (from odt in db.OrderDetails
                     where odt.CustomerId.Equals(user.Id)
                     select odt).ToList();

                 foreach (var items in orderDetailsTable)
                 {
                     db.OrderDetails.Remove(items);
                 }

                 // Customer order Delete
                var orderTable = (from pt in db.Orders
                    where pt.CustomerId.Equals(user.Id)
                    select pt).ToList();
                foreach (var items in orderTable)
                {
                    db.Orders.Remove(items);
                }

                // Customer Product Rating Delete
                var productRatingTable = (from prt in db.ProductRatings
                    where prt.CustomerId.Equals(user.Id) 
                    select prt).ToList();
                foreach (var items in productRatingTable)
                {
                    db.ProductRatings.Remove(items);
                }
                    
                // Customer Service Rating Delete
                var serviceRatingTable = (from srt in db.ServiceRatings
                    where srt.CustomerId.Equals(user.Id)
                    select srt).ToList();
                foreach (var items in serviceRatingTable)
                {
                    db.ServiceRatings.Remove(items);
                }

                // Delete Customer From Customer Table
                var customerTable = (from ct in db.Customers
                                   where ct.UserId.Equals(user.Id)
                                   select ct).FirstOrDefault();
                db.Customers.Remove(customerTable);
                
                // Customer Delete From User Table
                db.Users.Remove(user);
                db.SaveChanges();
            }
            else if (user.Role.Equals("Delivery-Boy"))
            {

                // Delete Delivery boys Services
                var servicesTable = (from st in db.Services
                    where st.DeliveryBoyId == user.Id
                    select st).ToList();

                foreach (var items in servicesTable)
                {
                    db.Services.Remove(items);
                }

                // Delete Delivery Boy all Delivery List
                var deliveryTable = (from dt in db.Deliverys
                    where dt.DeliveryBoyId == user.Id
                    select dt).ToList();
                foreach (var items in deliveryTable)
                {
                    db.Deliverys.Remove(items);
                }

                // Delete User from Delivery-Boy Table
                var deliveryBoyTable = (from dt in db.Delivery_Boys
                    where dt.UserId.Equals(user.Id)
                    select dt).FirstOrDefault();
                db.Delivery_Boys.Remove(deliveryBoyTable);

                // Delivery Boy Delete From User Table
                db.Users.Remove(user);
                db.SaveChanges();


            }
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        // not used
        public List<User> GetByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

