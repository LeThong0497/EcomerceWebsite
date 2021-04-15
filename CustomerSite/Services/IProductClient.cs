using ShareViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerSite.Services
{
    public interface IProductClient
    {
        Task<IList<ProductVm>> GetProducts();

        Task<ProductVm> GetProduct(int id);

        Task<IList<ProductVm>> GetProductsByBrand(int id);
    }
}