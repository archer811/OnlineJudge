using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineJudge.Models
{
    public class AuthorModel
    {

        //public int AuthorID{get;set;}

        [Required]
        [StringLength(64)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email{get;set;}

        [Required]
        [StringLength(45,MinimumLength=1)]
        [DataType(DataType.Password)]
        public string Password{get;set;}

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [Required]
        [StringLength(45,MinimumLength=1)]
        public string UserName{get;set;}

        //public int TotalScore{get;set;}

    }
}