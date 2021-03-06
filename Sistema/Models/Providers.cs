﻿ using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class Providers
    {
        [Key]
        public Int32 ProvidersId { get; set; }
        [Required]
        [StringLength(100)]
        public string ProviderName { get; set; }
        [Required]
        [StringLength(14)]
        public string ProviderRtn { get; set; }
        [Required]
        [StringLength(8)]
        public string ProviderPhone1 { get; set; }
        public string ProviderPhone2 { get; set; }
        public string ProviderAddress { get; set; }

        public Int32 CityId { get; set; }




        [Required]
        [StringLength(100)]
        public string ProviderEmail { get; set; }
        [Required]
        [StringLength(50)]
        public string ProviderContact { get; set; }
        [StringLength(50)]
        public string ContactPosition { get; set; }

      
       public virtual City City { get; set; }
        public virtual ICollection<Product> Products { get; set; } 
       

    }
}
