using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Food.Repo;
using Food.Models;

namespace Food.Biz
{
    public class FoodBiz
    {
        public IEnumerable<Food.Models.Food> GetFoods()
        {
            var foodRepo = new FoodRepo();
            var foods = foodRepo.GetFoods();
            return foods;
        }
        public IEnumerable<FoodModel> GetPrimaryFoods()
        {
            var foodRepo = new FoodRepo();
            var foods = foodRepo.GetFoods().Where(f => f.Type == 1)
                .Select(f => new FoodModel(){ Id = f.Id,Name = f.Name,Type = f.Type})
                .OrderBy(f => f.Name);
            return foods;
        }
        public IEnumerable<FoodModel> GetSecondaryFoods()
        {
            var foodRepo = new FoodRepo();
            var foods = foodRepo.GetFoods().Where(f => f.Type == 2)
                .Select(f => new FoodModel(){ Id = f.Id,Name = f.Name,Type = f.Type})
                .OrderBy(f => f.Name);
            return foods;
        }
    }
}