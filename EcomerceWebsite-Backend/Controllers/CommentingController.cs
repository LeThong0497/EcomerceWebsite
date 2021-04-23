using EcomerceWebsite_Backend.Data;
using EcomerceWebsite_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareViewModel;
using System.Threading.Tasks;

namespace EcomerceWebsite_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class CommentingController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CommentingController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

         [HttpPost]
         [Authorize]
        public async Task<ActionResult> PostCommenting (CommentingVm commentingVm)
        {
            var comment = new Comment();
            comment.Star = commentingVm.star;
            comment.Date = commentingVm.date;
            comment.Content = commentingVm.content;
            comment.ProductID = commentingVm.productId;
            comment.UserName = commentingVm.userName;
            _applicationDbContext.Comments.Add(comment);
           await _applicationDbContext.SaveChangesAsync();

             return StatusCode(200);
        }
    }
}
