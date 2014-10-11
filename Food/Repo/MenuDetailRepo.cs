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
    }
}