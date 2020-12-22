using PagedList;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TodoListMVC.Models;

namespace TodoListMVC.Controllers
{
    public class UsersController : Controller
    {
        private PGDbContext _db;

        public UsersController(PGDbContext db)
        {
            _db = db;
        }
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetPaging(int? page)
        {
            var listusers = _db.Users.ToList();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialViewUser", listusers.ToPagedList(pageNumber, pageSize));
        }

    //    // GET: Users/Details/5
    //    public ActionResult Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        User user = _db.Users.Find(id);
    //        if (user == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(user);
    //    }

    //    // GET: Users/Create
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: Users/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create([Bind(Include = "Id,Username,Password,Name,Address,Email,PhoneNumber,Role")] User user)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _db.Users.Add(user);
    //            _db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }

    //        return View(user);
    //    }

    //    // GET: Users/Edit/5
    //    public ActionResult Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        User user = _db.Users.Find(id);
    //        if (user == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(user);
    //    }

    //    // POST: Users/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit([Bind(Include = "Id,Username,Password,Name,Address,Email,PhoneNumber,Role")] User user)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _db.Entry(user).State = EntityState.Modified;
    //            _db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        return View(user);
    //    }

    //    // GET: Users/Delete/5
    //    public ActionResult Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        User user = _db.Users.Find(id);
    //        if (user == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(user); 
    //    }

    //    // POST: Users/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        User user = _db.Users.Find(id);
    //        _db.Users.Remove(user);
    //        _db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            _db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }
    }
}
