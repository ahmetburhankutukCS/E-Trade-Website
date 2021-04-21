namespace FoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderInfo")]
    public partial class OrderInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderInfo()
        {
            Baskets = new HashSet<Basket>();
            Payments = new HashSet<Payment>();
            Shippings = new HashSet<Shipping>();
        }

        [Key]
        public int OrderID { get; set; }

        public int FoodID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public double? Price { get; set; }

        public double? TotalPrice { get; set; }

        public int? Amount { get; set; }

        public DateTime? Edate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Basket> Baskets { get; set; }

        public virtual Food Food { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
