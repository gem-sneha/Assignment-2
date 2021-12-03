using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class ResetPswd
    {
        public string EmailAddress { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }
}