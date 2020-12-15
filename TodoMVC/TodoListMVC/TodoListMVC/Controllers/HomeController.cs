using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Index()
        {
            var t = _context.Accounts.ToList();
            var x = _context.Employees.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}