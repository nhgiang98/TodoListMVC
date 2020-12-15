using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TodoListMVC.Models;
namespace TodoListMVC.Controllers
{
    public class HomeController : Controller
    {
        PGDbContext _context;

        public HomeController()
        {
            _context = new PGDbContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(string returnUrl, Account account)
        {
            var user = _context.Accounts.Where(x => x.Username == account.Username && x.Password == account.Password).FirstOrDefault();

            if(user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                if(Url.IsLocalUrl(returnUrl) && returnUrl.Length>1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {

            }
            return View();
        }

        [Authorize]
        [AllowAnonymous]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
       
    }
}