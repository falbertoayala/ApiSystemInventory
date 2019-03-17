using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class PurchaseDetail
    {
        [Key]
        public Int32 PurchaseDetailId { get; set; }

        public Int32 PurchaseId { get; set; }
        public Int32? ProductId { get; set; }

        public Int32 Quantity { get; set; }

        public virtual Purchase Purchase { get; set; }
        public virtual Product Product { get; set; }





    }
}
