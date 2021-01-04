using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using TodoListMVC.Common;
using TodoListMVC.Constant;
using TodoListMVC.Models;
namespace TodoListMVC.Controllers
{
    public class HomeController : Controller
    {
        private PGDbContext _context;

        public HomeController(PGDbContext context)
        {
            _context = context;
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
        [ValidateAntiForgeryToken]
        public ActionResult Login(string returnUrl, User user)
        {
            var username = _context.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else if (user.Role == RoleConstant.ADMINROLE)
                {
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        [AllowAnonymous]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            var username = _context.Users.Where(x => x.Username == user.Username).FirstOrDefault();
            if (username == null)
            {
                _context.Users.Add(new User
                {
                    Username = user.Username,
                    Password = EncryptHelper.Encrypt(user.Password),
                    Name = user.Name,
                    Address = user.Address,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Role = RoleConstant.USERROLE,
                });
                _context.SaveChanges();
            }
            return View("SignUp");
        }

    }
}