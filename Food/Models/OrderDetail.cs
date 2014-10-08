namespace Food.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int FoodId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Food Food { get; set; }

        public virtual Order Order { get; set; }
    }
}
