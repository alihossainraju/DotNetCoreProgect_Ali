using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProgect_Ali.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Food Name")]
        public string FoodName { get; set; }

        [Required]
        [StringLength(100)]
        public string Quality { get; set; }

        [Required]
        [StringLength(100)]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Purchased Date")]
        public DateTime PurchasesDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Purchased Time")]
        public DateTime PurchasesTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Place { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirm password")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm Password should be match with password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string Image { get; set; }
    }
}
