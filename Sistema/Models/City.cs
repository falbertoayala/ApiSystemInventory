using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class City
    {
        [Key]
        public Int32 CityId { get; set; }
        public string CityName { get; set; }


        public virtual ICollection<City>Cities { get; set; }
    }
}
