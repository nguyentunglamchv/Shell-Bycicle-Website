using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SellBicycleWebsite.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name = "Email")]
        public string tendn { get; set; }
        [Display(Name = "Password")]
        public string mk { get; set; }
    }
}