using ShareViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerSite.Services
{
    public interface IBrandClient
    {
        Task<IList<BrandVm>> GetBrands();

        Task<BrandVm> GetBrand(int id);
    }
}
