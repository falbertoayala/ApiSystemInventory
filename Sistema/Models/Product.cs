using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class Product
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
        [Range(0, Int32.MaxValue)]
        public Int32 Quantity { get; set; }

        public bool MakePurchase(int qty)
        {
          if ((this.Quantity += qty)>=1)
            {
                this.Quantity += qty;
                return true;

            }
            return false;
        }

        public bool MakeRequest(int qty)
        {

            if ((this.Quantity - qty) > 0)
            {
                this.Quantity -= qty;

                return true;
            }

            return false;
        }


        public virtual ProductBrand ProductBrand { get; set; }
        public virtual Providers Providers { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual TypeProduct TypeProduct { get; set; }

    }
}
