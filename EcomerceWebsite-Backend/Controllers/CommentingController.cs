using EcomerceWebsite_Backend.Data;
using EcomerceWebsite_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareViewModel;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcomerceWebsite_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class CommentingController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CommentingController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        [Authorize]
        public async Task<StatusCodeResult> PostCommenting (FormCollection f,string userName,int productID)
        {
            var commentVm = new Comment();
            commentVm.Star = Convert.ToInt32(f["radio"]);
            commentVm.Date = DateTime.Today;
            commentVm.Content = f["content"];
            commentVm.ProductID = productID;
            commentVm.UserName = userName;
            _applicationDbContext.Comments.Add(commentVm);
           await _applicationDbContext.SaveChangesAsync();

             return StatusCode(200);
        }
    }
}
