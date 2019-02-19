using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class Users
    {
        [Key]
        public Int32 UserId { get; set; }
        public string UserName { get; set; }
        public string UserSecondName { get; set; }
        public string UserAccount { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        


    }
}
