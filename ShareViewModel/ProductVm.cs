using System.Collections.Generic;

namespace ShareViewModel
{
    public class ProductVm
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string CPU { get; set; }

        public string Screen { get; set; }

        public string HardDrive { get; set; }

        public string Card { get; set; }

        public string Size { get; set; }

        public string GateWay { get; set; }

        public List<string> Image { get; set; }
        public int BrandID { get; set; }
        
    }
}
