namespace FoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Basket")]
    public partial class Basket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Basket()
        {
            BasketDetails = new HashSet<BasketDetail>();
        }

        public int BasketID { get; set; }

        public int OrderID { get; set; }

        public double? BasketPrice { get; set; }

        [StringLength(500)]
        public string BasketNot { get; set; }

        public virtual OrderInfo OrderInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BasketDetail> BasketDetails { get; set; }
    }
}
