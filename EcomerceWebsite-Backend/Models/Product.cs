using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EcomerceWebsite_Backend.Models
{
    public class Product
    {

        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [StringLength(80)]
        public string CPU { get; set; }

        [StringLength(80)]
        public string Screen { get; set; }

        [StringLength(80)]
        public string HardDrive { get; set; }

        [StringLength(80)]
        public string Card { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        [StringLength(80)]
        public string GateWay { get; set; }

        [Required]
        public string Image { get; set; }
        public int BrandID { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
