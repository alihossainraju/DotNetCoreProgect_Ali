using DotNetCoreProgect_Ali.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProgect_Ali.ViewModels
{
    public class FoodViewModel: EditImageViewModel
    {
        [Required]

        [Display(Name = "Food Name")]
        public string FoodName { get; set; }

        [Required]
        [MyValidation2]
        public string Quality { get; set; }

        [Required]

        public int Quantity { get; set; }

        [Required]
        [CustomHireDate]
        [DataType(DataType.Date)]
        [Display(Name = "Purchased Date")]
        public DateTime PurchasesDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Purchased Time")]
        public DateTime PurchasesTime { get; set; }

        [Required]
 
        public string Place { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirm password")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm Password should be match with password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
