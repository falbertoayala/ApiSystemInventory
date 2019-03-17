using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class Storage
    {
        [Key]
        public Int32 StorageId { get; set; }
        [Required]
        [StringLength(100)]
        public String StorageDescription { get; set; }
        [Required]
        [StringLength(100)]
        public string StorageUbication { get; set; }

        public virtual ICollection<Product> Product2s { get; set; }
    }

}
