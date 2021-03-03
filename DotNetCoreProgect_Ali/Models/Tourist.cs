using DotNetCoreProgect_Ali.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProgect_Ali.Models
{
    public class Tourist
    {       
        public int TouristId { get; set; }

        [Display(Name = "Tourist Name")]
        [Required(ErrorMessage = "Please input your name here!!!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string TouristName { get; set; }

         //Custom validation
        [Required(ErrorMessage = "Please input your type of room here!!!")]
        [MyValidation]
        public string RoomType { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please input your phone number here!!!")]
        public string Contact { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please input your E-mail address here!!!")]
        [EmailAddress]

        public string Email { get; set; }
        [DataType(DataType.Date)]
        [CustomHireDate(ErrorMessage = "Hire Date must be less than or equal to Today's Date")]
        public DateTime DateOfBirth { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
