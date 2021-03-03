using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProgect_Ali.Models
{
    public class Hotel
    {
        public int HotelID { get; set; }
        [Display(Name = "Hotel Name")]
        [Required(ErrorMessage = "Please input hotel name here!!!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 character")]
        public string HotelName { get; set; }
        public int TouristId { get; set; }

        [Display(Name = "Joining Date")]
        [Required(ErrorMessage = "Please input your Joining date here!!!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime JoinDate { get; set; }

        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "Please input your release date here!!!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Room Charge")]
        [Required(ErrorMessage = "Please input your room charge here!!!")]
        [Range(99, 99999, ErrorMessage = "Charge must be 99 to 99999 tk.")]
        public int RoomCharge { get; set; }

        [Display(Name = "Service Charge")]
        [Required(ErrorMessage = "Please input your service charge here!!!")]
        [Range(99, 99999, ErrorMessage = "Charge must be 99 to 99999 tk.")]
        public int ServiceCharge { get; set; }

        [Display(Name = "Food Cost")]
        [Required(ErrorMessage = "Please input your food cost here!!!")]
        [Range(99, 99999, ErrorMessage = "Charge must be 99 to 99999 tk.")]
        public int FoodCost { get; set; }
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal Total { get { return (RoomCharge + ServiceCharge + FoodCost); } }
        public virtual Tourist Tourist { get; set; }
    }
}
