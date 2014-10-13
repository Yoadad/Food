using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Food.Models;
using Food.Repo;
using Food.Services;

namespace Food.Biz
{
    public class MenuBiz
    {
        public IEnumerable<MenuModel> GetWeekMenu(DateTime date)
        {
            var menus = new List<MenuModel>();
            var sundayDate = DateService.GetSundayOfWeek(date);
            for (int i = 1; i < 6; i++)
            {
                var dayDate = sundayDate.AddDays(i);
                AddMenuIfDontExistInThisDate(dayDate);
                var menu = GetMenuByDate(dayDate);
                menus.Add(menu);
            }
            return menus;
        }
        
        public void AddMenuIfDontExistInThisDate(DateTime date)
        {
            var repo = new MenuRepo();
            var menu = repo.GetMenuByDate(date);
            if (menu == null)
            {
                repo.AddMenu(new Menu()
                {
                    Name = DateService.GetTextDayOfWeek(date),
                    Date = date
                });
            }
        }
        public MenuModel GetMenuByDate(DateTime date)
        {
            var menuRepo = new MenuRepo();
            var menuDetailRepo = new MenuDetailRepo();
            var foodRepo = new FoodRepo();
            var menu = menuRepo.GetMenuByDate(date);
            var menuModel = new MenuModel()
            {
                Id = menu.Id,
                Name = menu.Name,
                Date = menu.Date,
                MenuDetails = menuDetailRepo.GetMenuDetailByMenu(menu.Id)
                            .Select(md => new MenuDetailModel()
                            {
                                Id = md.Id,
                                Food = foodRepo.GetFoodsById(md.FoodId).Select(f => new FoodModel() { 
                                                                                Id = f.Id,
                                                                                Name = f.Name,
                                                                                Type = f.Type
                                                                            }).First()
                            })
            };
            
            return menuModel;
        }

        public void SaveMenu(IEnumerable<MenuDetail> menuDetails)
        {
            var menuRepo = new MenuRepo();
            var menuDetailRepo = new MenuDetailRepo();
            RemoveMenuDetails(menuDetails.First().MenuId);
            foreach (var menuDetail in menuDetails)
            {
                AddMenuDetail(menuDetail);
            }
        }

        public void RemoveMenuDetails(int menuId)
        {
            var menudetailRepo = new MenuDetailRepo();
            var menuDetails = menudetailRepo.GetMenuDetailByMenu(menuId);
            foreach (var detail in menuDetails)
            {
                menudetailRepo.RemoveMenuDetail(detail);
            }
        }

        public void AddOrEditMenuDetail(MenuDetail menuDetail)
        {
            var menuDetailRepo = new MenuDetailRepo();
            var detail = menuDetailRepo.GetMenuDetailById(menuDetail.Id);
            if (detail == null)
            {
                menuDetailRepo.AddMenuDetail(menuDetail);
            }
            else
            {
                menuDetailRepo.EditMenuDetail(menuDetail);
            }
        }
        public void AddMenuDetail(MenuDetail menuDetail)
        {
            var menuDetailRepo = new MenuDetailRepo();          
            menuDetailRepo.AddMenuDetail(menuDetail);
        }

    }
}