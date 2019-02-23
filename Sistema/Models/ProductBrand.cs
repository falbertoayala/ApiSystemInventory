using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class ProductBrand
    {
        [Key]
        public Int32 ProductBrandId { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductBrandName { get; set; }

        public virtual ICollection<Product2> Product2s { get; set; }

    }
}
