using System.ComponentModel.DataAnnotations;

namespace ShareViewModel
{
    public class BrandCreateRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
