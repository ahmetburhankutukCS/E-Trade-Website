namespace FoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        public int PaymentID { get; set; }

        public int OrderID { get; set; }

        public DateTime? Edate { get; set; }

        [StringLength(100)]
        public string PaymentDefinition { get; set; }

        public virtual OrderInfo OrderInfo { get; set; }
    }
}
