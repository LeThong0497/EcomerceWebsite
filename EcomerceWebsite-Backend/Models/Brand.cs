using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebsite_Backend.Models
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }                                                                                                                      

        public virtual ICollection<Product> Products { get; set; }

    }
}
