using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Food.Models
{
    public class MenuDetailViewModel
    {       
        public int FoodId { get; set; }
        public int MenuId { get; set; }
        public string Name { get; set; }
        public IEnumerable<FoodViewModel> FoodItems { get; set; }
    }

    public class FoodViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}