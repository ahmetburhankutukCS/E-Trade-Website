namespace FoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BasketDetail
    {
        [Key]
        public int BasketDetailsID { get; set; }

        public int? FoodID { get; set; }

        public int? BasketID { get; set; }

        public virtual Basket Basket { get; set; }

        public virtual Food Food { get; set; }
    }
}
