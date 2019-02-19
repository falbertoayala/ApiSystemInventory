using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class Medico
    {
        [Key]
        public Int32 MedicId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacmiento { get; set; }

    }
}
