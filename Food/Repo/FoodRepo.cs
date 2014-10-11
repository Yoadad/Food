using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Food.Models;

namespace Food.Repo
{
    public class FoodRepo
    {
        public Food.Models.Food GetFoodById(int id)
        {
            using (var db = new FoodContext())
            {
                var food = db.Foods.FirstOrDefault(f => f.Id == id);
                return food;
            }
        }
        public IEnumerable<Food.Models.Food> GetFoodsById(int id)
        {
            using (var db = new FoodContext())
            {
                var foods = db.Foods.Where(f => f.Id == id).ToList();
                return foods;
            }
        }

    }
}