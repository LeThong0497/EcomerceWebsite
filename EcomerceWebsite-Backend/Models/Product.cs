using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EcomerceWebsite_Backend.Models
{
    public class Product
    {

        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [StringLength(40)]
        public string CPU { get; set; }

        [StringLength(40)]
        public string Screen { get; set; }

        [StringLength(30)]
        public string HardDrive { get; set; }

        [StringLength(30)]
        public string Card { get; set; }

        [StringLength(30)]
        public string Size { get; set; }

        [StringLength(80)]
        public string GateWay { get; set; }

        public int CommentID { get; set; }

        [Required]
        public int BrandID { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
