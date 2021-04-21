namespace FoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FoodCompany")]
    public partial class FoodCompany
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FoodCompany()
        {
            BranchOffices = new HashSet<BranchOffice>();
            Categories = new HashSet<Category>();
            Shippings = new HashSet<Shipping>();
        }

        [Key]
        public int CompanyID { get; set; }

        public Guid? UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyDefinition { get; set; }

        [StringLength(200)]
        public string CompanyAddress { get; set; }

        [StringLength(20)]
        public string Country { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(20)]
        public string GSM { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BranchOffice> BranchOffices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
