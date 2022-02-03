using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication11.Model
{
    public class userinfo
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        public string fullname { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        [Compare("password")]
        public string confirmpassword { get; set; }
        [Required]
        public string token { get; set; }


    }
}
