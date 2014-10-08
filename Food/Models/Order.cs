namespace Food.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        public int StatusId { get; set; }

        public virtual OrderStatu OrderStatu { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
