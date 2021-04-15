using CustomerSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShareViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Controllers
{
    public class CommentingController : Controller
    {
        private readonly ICommentingClient _commentingClient;

        private readonly IConfiguration _configuration;

        public CommentingController(ICommentingClient commenting, IConfiguration configuration)
        {
            _commentingClient = commenting;
            _configuration = configuration;
        }
        public async Task<ActionResult> PostCommenting(IFormCollection f,int productId,string userName)
        {
            var CommentingVm = new CommentingVm();
            CommentingVm.star = Convert.ToInt32(f["rating"]);
            CommentingVm.date = DateTime.Today;
            CommentingVm.content = f["content"];
            CommentingVm.productId = Convert.ToInt32(productId);
            CommentingVm.userName = userName;
            await _commentingClient.PostCommenting(CommentingVm);

            string referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }
    }
}
