using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication11.Model
{
    public class autntecationmodel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
