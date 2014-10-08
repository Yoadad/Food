namespace Food.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Food")]
    public partial class Food
    {
        public Food()
        {
            MenuDetails = new HashSet<MenuDetail>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        public int Type { get; set; }

        public virtual ICollection<MenuDetail> MenuDetails { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
