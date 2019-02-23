using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class Product2
    {
        [Key]
        public Int32 ProductId { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductCode { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }
        [Required]
        public Decimal ProductCost { get; set; }
        [Required]
        public Int32 ProductBrandId { get; set; }
        [Required]
        public Int32 ProvidersId { get; set; }
        [Required]
        public Int32 StorageId { get; set; }
        [Required]
        public Int32 TypeProductId { get; set; }


        public virtual ProductBrand ProductBrand { get; set; }
        public virtual Providers Providers { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual TypeProduct TypeProduct { get; set; }

    }
}
