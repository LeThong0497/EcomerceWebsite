using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerSite.Services
{
   public interface ICommentingClient
    {
        Task<HttpResponseMessage> PostCommenting(CommentingVm commentingVm);
    }
}
