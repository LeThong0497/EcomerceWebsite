using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Services
{
   public interface ICommentingClient
    {
        Task<StatusCodeResult> PostCommenting(FormCollection f,string userName,int productId);
    }
}
