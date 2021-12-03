using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Gmail
    {   
        [Required(ErrorMessage = "Email is Required")]
        public string To { get; set; }
        [Required]
        public string From{ get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
    }
}