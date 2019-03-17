using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class RequisitionDetail
    {
        [Key]
        public Int32 RequisitionDetailId { get; set; }

        public Int32? RequisitionId { get; set; }
        public Int32? ProductId { get; set; }

        public Int32 Quantity { get; set; }
        
       public string Observation { get; set; }

        public virtual Requisition Requisition { get; set; }
        public virtual Product Product { get; set; }
    }
}
