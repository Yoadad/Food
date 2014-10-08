using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Food.Models
{
    public class FoodContext:DbContext
    {
        public FoodContext():base("Food")
        {
            
        }

        public DbSet<Food> Foods { get; set; }

        public DbSet<Company> Companies { get; set; }

    }
}