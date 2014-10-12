namespace Food.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public Menu()
        {
            MenuDetails = new HashSet<MenuDetail>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<MenuDetail> MenuDetails { get; set; }
    }

    public class MenuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public virtual IEnumerable<MenuDetailModel> MenuDetails { get; set; }
        public int Index { get; set; }
    }
}
