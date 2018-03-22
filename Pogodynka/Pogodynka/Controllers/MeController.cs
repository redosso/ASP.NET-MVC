using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using Pogodynka.Models;

namespace Pogodynka.Controllers
{
    //[Authorize]
    public class MeController : ApiController
    {
        private UserManager _userManager;

        public MeController()
        {
        }

        public MeController(UserManager userManager)
        {
            UserManager = userManager;
        }

        public UserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<UserManager>();                
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET api/Me
        public GetViewModel Get()
        {
            //var user = UserManager.FindById(User.Identity.GetUserId());
            // _userManager
           // IdentityUserRole identityUser;
            //user.Roles.Add(new IdentityUserRole() );
            //_userManager.AddToRole(User.Identity.GetUserId(), "Administrator");

            return new GetViewModel() { };//Hometown = user.Hometown };
        }
    }
}