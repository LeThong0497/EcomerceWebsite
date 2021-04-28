using EcomerceWebsite_Backend.Controllers;
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
    public class BrandControllerTest
    {
        private readonly SqlLite _fixture;

        public BrandControllerTest(SqlLite fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();

        }

        [Fact]
        public async Task PostBrand_Success()
        {
            var dbContext = _fixture.Context;
            var brand = new BrandCreateRequest { Name = "Test brand" };

            var controller = new BrandsController(dbContext);
            var result = await controller.PostBrand(brand);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<BrandVm>(createdAtActionResult.Value);
            Assert.Equal("Test brand", returnValue.Name);
        }

        [Fact]
        public async Task PutBrand_Success()
        {
            var dbContext = _fixture.Context;
            dbContext.Brands.Add(new Brand { Name = "Test brand" });
            await dbContext.SaveChangesAsync();

            var oldCategory = await dbContext.Brands.OrderByDescending(x => x.BrandID).FirstAsync();
            var category = new BrandCreateRequest { Name = "Test put category" };

            var controller = new BrandsController(dbContext);
            var result = await controller.PutBrand(oldCategory.BrandID, category);

            var returnValue = await dbContext.Brands.OrderByDescending(x => x.BrandID).FirstAsync();
            Assert.Equal("Test put category", returnValue.Name);
        }

        [Fact]
        public async Task DeleteCategory_Success()
        {
            var dbContext = _fixture.Context;
            dbContext.Brands.Add(new Brand { Name = "Test category" });
            await dbContext.SaveChangesAsync();

            var oldCategory = await dbContext.Brands.OrderByDescending(x => x.BrandID).FirstAsync();

            var controller = new BrandsController(dbContext);
            var result = await controller.DeleteBrand(oldCategory.BrandID);

            var returnValue = await dbContext.Brands.ToListAsync();
            Assert.Empty(returnValue);
        }

        [Fact]
        public async Task GetCategory_Success()
        {
            var dbContext = _fixture.Context;
            dbContext.Brands.Add(new Brand { Name = "Test category" });
            await dbContext.SaveChangesAsync();

            var controller = new BrandsController(dbContext);
            var result = await controller.GetBrands();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<BrandVm>>>(result);
            Assert.NotEmpty(actionResult.Value);
        }
    }

}
