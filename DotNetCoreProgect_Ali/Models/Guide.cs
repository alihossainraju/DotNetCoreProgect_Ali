using DotNetCoreProgect_Ali.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProgect_Ali.Models
{
    public class Guide
    {
        [Key]
        public int GuideId { get; set; }
        [MyValidation]
        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Guide Name")]
        [Required(ErrorMessage = "Must be filled Guide Name")]
        [MaxLength(12, ErrorMessage = "Maximum 12 characters only")]
        public string GuideName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Please input Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Present Address")]
        [Required(ErrorMessage = "Please input address")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "please input your Phone number.")]
        [MaxLength(11)]
        public string Phone { get; set; }

        [DisplayName("Salary")]
        [Required(ErrorMessage = "must be filled Salary.")]
        public int Salary { get; set; }

        [CustomHireDate]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }
    }
}