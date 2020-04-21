using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;

namespace RMDataManager.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {        
        public UserModel GetById()
        {
            //This way we're getting back the current logged user instead receiving UserId like a method parameter
            string UserId = RequestContext.Principal.Identity.GetUserId();

            UserData data = new UserData();

            return data.GetUserById(UserId).First();
        }
        
    }
}
