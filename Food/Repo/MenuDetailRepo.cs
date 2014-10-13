using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Food.Models;

namespace Food.Repo
{
    public class MenuDetailRepo
    {
        public List<MenuDetail> GetMenuDetailByMenu(int menuId)
        {
            using (var db = new FoodContext())
            {
                return db.MenuDetails
                        .Where(md => md.MenuId == menuId)
                        .ToList();
            }
        }
        public MenuDetail GetMenuDetailById(int id)
        {
            using (var db = new FoodContext())
            {
                var menuDetail = db.MenuDetails.FirstOrDefault(md => md.Id == id);
                return menuDetail;
            }
        }


        public void AddMenuDetail(MenuDetail menuDetail)
        {
            using (var db = new FoodContext())
            {
                db.MenuDetails.Add(menuDetail);
                db.SaveChanges();
            }
        }
        public void EditMenuDetail(MenuDetail menuDetail)
        {
            using (var db = new FoodContext())
            {
                db.MenuDetails.Attach(menuDetail);
                db.Entry(menuDetail).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void RemoveMenuDetail(MenuDetail menuDetail)
        {
            using (var db = new FoodContext())
            {
                var menuDetailToRemove = db.MenuDetails.FirstOrDefault(m => m.Id == menuDetail.Id);
                db.MenuDetails.Remove(menuDetailToRemove);
                db.SaveChanges();
            }
        }
        

    }
}