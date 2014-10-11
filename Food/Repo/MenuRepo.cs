using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Food.Models;

namespace Food.Repo
{
    public class MenuRepo
    {
        public Menu GetMenuByDate(DateTime date)
        {
            using (var db = new FoodContext())
            {
                var initialDate = new DateTime(date.Year,date.Month,date.Day,0,0,0);
                var finalDate = new DateTime(date.Year,date.Month,date.Day,23,59,59);
                var menu = db.Menus
                    .FirstOrDefault(m => m.Date >= initialDate && m.Date <= finalDate);
                return menu;
            }
        }

        public void AddMenu(Menu menu)
        {
            using (var db = new FoodContext())
            {
                db.Menus.Add(menu);
                db.SaveChanges();
            }
        }
        public void EditMenu(Menu menu)
        {
            using (var db = new FoodContext())
            {
                db.Menus.Attach(menu);
                db.Entry(menu).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void RemoveMenu(Menu menu)
        {
            using (var db = new FoodContext())
            {
                var menuToRemove = db.Menus.FirstOrDefault(m => m.Id == menu.Id);
                db.Menus.Remove(menuToRemove);
                db.SaveChanges();
            }
        }

    }
}