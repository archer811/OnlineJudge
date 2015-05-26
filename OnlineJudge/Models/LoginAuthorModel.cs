using OnlineJudge.Validate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJudge.Models
{
    public class LoginAuthorModel
    {
        
        [Required]
        [StringLength(64)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        //[LoginValidate()]
        public string Email { get; set; }


        
        [Required]
        [StringLength(45, MinimumLength = 1)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}