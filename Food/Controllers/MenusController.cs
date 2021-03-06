﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Food.Models;
using Food.Biz;

namespace Food.Controllers
{
    public class MenusController : Controller
    {
        private FoodContext db = new FoodContext();

        // GET: Menus
        public ActionResult Index()
        {
            
            return View(db.Menus.ToList());
        }

        // GET: Menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: Menus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Date")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Date")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        // GET: Menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu menu = db.Menus.Find(id);
            db.Menus.Remove(menu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MenuCalendar(int id = 0)
        {
            ViewBag.Index = id;

            var model = new WeekMenuModel();
            var date = DateTime.Today.AddDays(id * 7);
            var menuBiz = new MenuBiz();
            var foodBiz = new FoodBiz();
            var menus = menuBiz.GetWeekMenu(date);
            var primaryFoods = foodBiz.GetPrimaryFoods();
            var secondaryFoods = foodBiz.GetSecondaryFoods();

            model.Menus = menus;
            model.PrimaryFoods = primaryFoods;
            model.SecondaryFoods = secondaryFoods;

            return View(model);
        }

        [HttpPost]
        public ActionResult MenuCalendar([Bind(Include="Id,Name,Index") ]MenuModel menu)
        {
            ViewBag.Index = menu.Index;
            var menuBiz = new MenuBiz();
            var menuDetails = new List<MenuDetail>();

            for (int i = 0; i < 6; i++)
            {
                var foodId = int.Parse(this.Request.Params["food"+(i+1)]);
                menuDetails.Add(new MenuDetail() { MenuId = menu.Id, FoodId = foodId});
            }

            menuBiz.SaveMenu(menuDetails);
            return RedirectToAction("MenuCalendar", new { id=menu.Index});
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
