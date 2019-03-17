using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class RequisitionStatus
    {
        [Key]
        public Int32 RequisitionStatusId { get; set; }
        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        public ICollection<Requisition> Requisitions{ get; set; }
    }
}
