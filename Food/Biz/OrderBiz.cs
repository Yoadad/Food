using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Food.Models;
using Food.Services;
using Food.Repo;

namespace Food.Biz
{
    public class OrderBiz
    {
        public IEnumerable<OrderModel> GetWeekOrders(DateTime date,string userId)
        {
            var orders = new List<OrderModel>();
            var sundayDate = DateService.GetSundayOfWeek(date);
            for (int i = 1; i < 6; i++)
            {
                var dayDate = sundayDate.AddDays(i);
                AddMenuIfDontExistInThisDate(dayDate);
                var order = GetOrderByDate(dayDate,userId);
                orders.Add(order);
            }
            return orders;
        }

        public OrderModel GetOrderByDate(DateTime date,string userId)
        {
            var orderRepo = new OrderRepo();
            var order = orderRepo.GetOrderByDateAndUser(date,userId);
            var statusRepo = new StatuRepo();
            var status = statusRepo.GetOrderStatus(1);//1 = Pedido; 2 = Entregado; 3 = Cancelado
            var orderDetailRepo = new OrderDetailRepo();
            var foodRepo = new FoodRepo();
            var menu = GetMenuByDate(date);
            var orderModel = new OrderModel()
            {
                Date = date,
                UserId = userId,
                Menu = menu,
                OrderDetails = order == null ? new List<OrderDetailModel>() : orderDetailRepo.GetOrderDetailsByOrder(order.Id)
                .Select(od => new OrderDetailModel() { 
                    Food = foodRepo.GetFoodById(od.FoodId)
                })
            };
            return orderModel;
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
                                Food = foodRepo.GetFoodsById(md.FoodId).Select(f => new FoodModel()
                                {
                                    Id = f.Id,
                                    Name = f.Name,
                                    Type = f.Type
                                }).First()
                            })
            };

            return menuModel;
        }

    }
}