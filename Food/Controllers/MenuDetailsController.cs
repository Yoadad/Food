using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Food.Models;

namespace Food.Controllers
{
    public class MenuDetailsController : Controller
    {
        private FoodContext db = new FoodContext();

        // GET: MenuDetails
        public ActionResult Index()
        {
            var menuDetails = db.MenuDetails.Include(m => m.Food).Include(m => m.Menu);
            return View(menuDetails.ToList());
        }

        // GET: MenuDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuDetail menuDetail = db.MenuDetails.Find(id);
            if (menuDetail == null)
            {
                return HttpNotFound();
            }
            return View(menuDetail);
        }

        // GET: MenuDetails/Create
        public ActionResult Create()
        {
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name");
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Name");
            return View();
        }

        // POST: MenuDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MenuId,FoodId")] MenuDetail menuDetail)
        {
            if (ModelState.IsValid)
            {
                db.MenuDetails.Add(menuDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", menuDetail.FoodId);
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Name", menuDetail.MenuId);
            return View(menuDetail);
        }

        // GET: MenuDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuDetail menuDetail = db.MenuDetails.Find(id);
            if (menuDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", menuDetail.FoodId);
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Name", menuDetail.MenuId);
            return View(menuDetail);
        }

        // POST: MenuDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MenuId,FoodId")] MenuDetail menuDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", menuDetail.FoodId);
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Name", menuDetail.MenuId);
            return View(menuDetail);
        }

        // GET: MenuDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuDetail menuDetail = db.MenuDetails.Find(id);
            if (menuDetail == null)
            {
                return HttpNotFound();
            }
            return View(menuDetail);
        }

        // POST: MenuDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuDetail menuDetail = db.MenuDetails.Find(id);
            db.MenuDetails.Remove(menuDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
