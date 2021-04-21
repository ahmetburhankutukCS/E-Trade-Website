namespace FoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shipping")]
    public partial class Shipping
    {
        [Key]
        public int CargoID { get; set; }

        [StringLength(50)]
        public string CargoName { get; set; }

        public int? OrderID { get; set; }

        public int? CompanyID { get; set; }

        public int? OfficeID { get; set; }

        [StringLength(100)]
        public string CargoDefinition { get; set; }

        public virtual BranchOffice BranchOffice { get; set; }

        public virtual FoodCompany FoodCompany { get; set; }

        public virtual OrderInfo OrderInfo { get; set; }
    }
}
