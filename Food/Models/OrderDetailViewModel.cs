using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Food.Models
{
    public class OrderDetailViewModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int Id { get; set; }
        public IEnumerable<MenuDetailViewModel> Menutems { get; set; }        
    }
}