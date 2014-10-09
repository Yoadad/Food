namespace Food.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuDetail")]
    public partial class MenuDetail
    {
        public int Id { get; set; }

        public int MenuId { get; set; }

        public int FoodId { get; set; }       

        public virtual Food Food { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
