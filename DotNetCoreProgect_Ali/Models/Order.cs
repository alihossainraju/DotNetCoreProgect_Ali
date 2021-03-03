using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProgect_Ali.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public long ID { get; set; }

        [Required, Display(Name = "Food Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Column(TypeName = "Image")]
        public byte[] Image { get; set; }


        [DataType(DataType.Date)]
        public DateTime BuyingDate { get; set; }

        [Required]
        public long Quantity { get; set; }

        [ForeignKey("Traveller")]
        public long TravellerID { get; set; }


        public virtual Traveller Traveller { get; set; }
    }
}
