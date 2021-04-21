namespace FoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CreditCard")]
    public partial class CreditCard
    {
        [Key]
        public int Cardno { get; set; }

        [StringLength(30)]
        public string CardName { get; set; }

        [StringLength(5)]
        public string CardExpireDate { get; set; }

        public int? SecurityCode { get; set; }

        [StringLength(20)]
        public string CardClass { get; set; }
    }
}
