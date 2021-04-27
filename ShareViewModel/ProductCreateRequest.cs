using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareViewModel
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string CPU { get; set; }

        public string Screen { get; set; }

        public string HardDrive { get; set; }

        public string Card { get; set; }

        public string Size { get; set; }

        public string GateWay { get; set; }

        public int BrandID { get; set; }

        public List<string> Images { get; set; }

    }
}
