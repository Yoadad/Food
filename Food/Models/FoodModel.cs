using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Food.Models
{

    public class WeekMenuModel
    {
        public IEnumerable<MenuModel> Menus { get; set; }
        public IEnumerable<FoodModel> PrimaryFoods { get; set; }
        public IEnumerable<FoodModel> SecondaryFoods { get; set; }
    }


    public class MenuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<MenuDetailModel> MenuDetails { get; set; }
        public IEnumerable<FoodModel> Foods { get; set; }
        public int Index { get; set; }
    }

    public class MenuDetailModel
    {
        public int Id { get; set; }
        public FoodModel Food { get; set; }
    }
    public class FoodModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public bool Selected { get; set; }
    }

    public class WeekOrderModel
    {
        public int Index { get; set; }
        public IEnumerable<MenuModel> Menus { get; set; }
        public IEnumerable<OrderModel> Orders { get; set; }
    }

    public class OrderModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public OrderStatu Status { get; set; } 
        public MenuModel Menu { get; set; }
        public IEnumerable<OrderDetailModel> OrderDetails { get;set; }
    }
    public class OrderDetailModel
    {
        public Food Food { get; set; }
    }
}