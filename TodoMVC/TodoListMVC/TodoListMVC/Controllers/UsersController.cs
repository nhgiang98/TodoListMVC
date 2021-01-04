﻿using PagedList;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TodoListMVC.Models;
using TodoListMVC.Services;

namespace TodoListMVC.Controllers
{
    public class UsersController : Controller
    {
        private IUsersService _userService;

        public UsersController(IUsersService userServices)
        {
            _userService = userServices;
        }
        // GET: Users
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetPaging(int? page)
        {
            var listusers = _userService.GetAll();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialViewUser", listusers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = _userService.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //// GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password,Name,Address,Email,PhoneNumber,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                _userService.AddNewUser(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = _userService.GetById(id.Value);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Address,Email,PhoneNumber,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                _userService.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = _userService.GetById(id.Value);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction("Index");

        }
    }
}
