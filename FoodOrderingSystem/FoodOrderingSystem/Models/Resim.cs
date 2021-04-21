namespace FoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resim")]
    public partial class Resim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Resim()
        {
            Categories = new HashSet<Category>();
            Foods = new HashSet<Food>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string BuyukYol { get; set; }

        [StringLength(250)]
        public string OrtaYol { get; set; }

        [StringLength(250)]
        public string KucukYol { get; set; }

        public int? Varsayılan { get; set; }

        public byte? SiraNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Food> Foods { get; set; }
    }
}
