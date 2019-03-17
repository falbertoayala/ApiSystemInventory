using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class Purchase
    {
        [Key]
        public Int32 PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Int32 ProvidersId { get; set; }

        



        public virtual Providers Providers { get; set; }

        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }


    }
}
