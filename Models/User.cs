using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        

        [Required(ErrorMessage = "Date of Birth is Required")]
        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }


        [Required(ErrorMessage ="Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }


       
        public string ResetPasswordCode { get; set; }
    }
}