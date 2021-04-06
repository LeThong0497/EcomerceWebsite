using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceWebsite_Backend.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        public string ImageName { get; set; }

        [Required]
        public int ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}
