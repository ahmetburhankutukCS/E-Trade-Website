namespace FoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Foods = new HashSet<Food>();
        }

        public int CategoryID { get; set; }

        public int? CompanyID { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(200)]
        public string CategoryDefinition { get; set; }

        public int? ResimID { get; set; }

        public virtual FoodCompany FoodCompany { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Food> Foods { get; set; }

        public virtual Resim Resim { get; set; }
    }
}
