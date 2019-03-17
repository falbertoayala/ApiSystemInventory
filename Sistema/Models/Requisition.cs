using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class Requisition
    {
        [Key]
        public Int32 RequisitionId { get; set; }
        public DateTime RequistionDate { get; set; }
        [Required]
        [StringLength(50)]
        public string Class { get; set; }
        [Required]
        [StringLength(50)]
        public string ReqPracticeName { get; set; }
        [Required]
        [StringLength(50)]
        public String Section { get; set; }
        public DateTime ClassHour { get; set; }

        public DateTime PracticeDate { get; set; }

        public  string StatusRequisitionDate {get; set;}

        public Int32? StorageId { get; set; }

        public Int32? RequisitionDetailId { get; set; }
        public Int32? RequisitionStatusId { get; set; }


        public virtual Storage Storage { get; set; }

        public virtual RequisitionStatus RequisitionStatus { get; set; }

        public virtual ICollection<RequisitionDetail> RequisitionDetails { get; set; }
    }
}
