using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProgect_Ali.Models
{
    [Table("Traveller")]
    public class Traveller
    {
        [Key]
        public long ID { get; set; }

        [Required, Display(Name = "Traveller")]
        public string Name { get; set; }

        public virtual IList<Order> Orders { get; set; }
    }
}
