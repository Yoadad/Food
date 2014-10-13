using Food.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Food.Repo
{
    public class OrderRepo
    {
        public Order GetOrderByDateAndUser(DateTime date,string userId)
        {
            using (var db = new FoodContext())
            {
                var initialDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                var finalDate = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
                var order = db.Orders
                    .FirstOrDefault(o => o.Date >= initialDate && o.Date <= finalDate && o.UserId == userId);
                return order;
            }        
        }
        public void AddOrder(Order order)
        {
            using (var db = new FoodContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }
        public void EditOrder(Order order)
        {
            using (var db = new FoodContext())
            {
                db.Orders.Attach(order);
                db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void RemoveOrder(Order order)
        {
            using (var db = new FoodContext())
            {
                var orderToRemove = db.Orders.FirstOrDefault(o => o.Id == order.Id);
                db.Orders.Remove(orderToRemove);
                db.SaveChanges();
            }
        }

    }
}