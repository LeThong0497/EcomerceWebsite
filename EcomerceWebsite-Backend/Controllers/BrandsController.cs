using EcomerceWebsite_Backend.Data;
using EcomerceWebsite_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceWebsite_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class BrandsController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BrandsController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<BrandVm>>> GetBrands()
        {
            return await _applicationDbContext.Brands
                .Select(x => new BrandVm { BrandId = x.BrandID })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<BrandVm>> GetBrand(int id)
        {
            var brand = await _applicationDbContext.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            var brandVm = new BrandVm
            {
                BrandId = brand.BrandID,
                Name = brand.Name
            };

            return brandVm;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutBrand(int id, BrandCreateRequest brandCreateRequest)
        {
            var _brand = await _applicationDbContext.Brands.FindAsync(id);

            if (_brand == null)
            {
                return NotFound();
            }

            _brand.Name = brandCreateRequest.Name;
            await _applicationDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<BrandVm>> PostBrand(BrandCreateRequest brandCreateRequest)
        {
            var _brand = new Brand
            {
                Name = brandCreateRequest.Name
            };

            _applicationDbContext.Brands.Add(_brand);
            await _applicationDbContext.SaveChangesAsync();
            return CreatedAtAction("GetBrands", new { id = _brand.BrandID }, new BrandVm { BrandId = _brand.BrandID, Name = _brand.Name });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _applicationDbContext.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _applicationDbContext.Brands.Remove(brand);
            await _applicationDbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
        
         
    
