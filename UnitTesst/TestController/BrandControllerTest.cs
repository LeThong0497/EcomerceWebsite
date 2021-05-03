using EcomerceWebsite_Backend.Controllers;
using EcomerceWebsite_Backend.Data;
using EcomerceWebsite_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTesst.TestController
{
    public class BrandControllerTest:IClassFixture<SqlLite>
    {
        private readonly SqlLite _fixture;
        private readonly ApplicationDbContext _applicationDbContex;

        public BrandControllerTest(SqlLite fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
            _applicationDbContex = _fixture.Context;
        }

        [Fact]
        public async Task PostBrand_Success()
        {
            var brand = new BrandCreateRequest { Name = "Test brand" };

            var controller = new BrandsController(_applicationDbContex);
            var result = await controller.PostBrand(brand);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<BrandVm>(createdAtActionResult.Value);
            Assert.Equal("Test brand", returnValue.Name);
        }

        [Fact]
        public async Task PutBrand_Success()
        {
            _applicationDbContex.Brands.Add(new Brand { Name = "Test brand" });
            await _applicationDbContex.SaveChangesAsync();

            var oldCategory = await _applicationDbContex.Brands.OrderByDescending(x => x.BrandID).FirstAsync();
            var category = new BrandCreateRequest { Name = "Test put category" };

            var controller = new BrandsController(_applicationDbContex);
            var result = await controller.PutBrand(oldCategory.BrandID, category);

            var returnValue = await _applicationDbContex.Brands.OrderByDescending(x => x.BrandID).FirstAsync();
            Assert.Equal("Test put category", returnValue.Name);
        }

        [Fact]
        public async Task DeleteCategory_Success()
        {
            _applicationDbContex.Brands.Add(new Brand { Name = "Test category" });
            await _applicationDbContex.SaveChangesAsync();

            var oldCategory = await _applicationDbContex.Brands.OrderByDescending(x => x.BrandID).FirstAsync();

            var controller = new BrandsController(_applicationDbContex);
            var result = await controller.DeleteBrand(oldCategory.BrandID);

            var returnValue = await _applicationDbContex.Brands.ToListAsync();
            Assert.Empty(returnValue);
        }

        [Fact]
        public async Task GetCategory_Success()
        {
           
            _applicationDbContex.Brands.Add(new Brand { Name = "Test category" });
            await _applicationDbContex.SaveChangesAsync();

            var controller = new BrandsController(_applicationDbContex);
            var result = await controller.GetBrands();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<BrandVm>>>(result);
            Assert.NotEmpty(actionResult.Value);
        }
    }

}
