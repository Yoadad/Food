using System;
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
    public class OrdersController : Controller
    {
        private FoodContext db = new FoodContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.OrderStatu);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.OrderStatus, "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Name,StatusId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.OrderStatus, "Id", "Name", order.StatusId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.OrderStatus, "Id", "Name", order.StatusId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Name,StatusId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.OrderStatus, "Id", "Name", order.StatusId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult OrderCalendar(int id = 0)
        {
            ViewBag.Index = id;

            var model = new WeekOrderModel();
            var date = DateTime.Today.AddDays(id * 7);
            var menuBiz = new MenuBiz();
            var menus = menuBiz.GetWeekMenu(date);
            var orderBiz = new OrderBiz();
            var orders = orderBiz.GetWeekOrders(date, User.Identity.ToString());
            
            model.Menus = menus;
            model.Orders = orders;
            return View("~/Views/Orders/WeekOrders.cshtml", model);
        }

        [HttpPost]
        public ActionResult OrderCalendar([Bind(Include = "Id,Name,Index")]MenuModel menu)
        {
            ViewBag.Index = menu.Index;
            var menuBiz = new MenuBiz();
            var menuDetails = new List<MenuDetail>();

            for (int i = 0; i < 6; i++)
            {
                var foodId = int.Parse(this.Request.Params["food" + (i + 1)]);
                menuDetails.Add(new MenuDetail() { MenuId = menu.Id, FoodId = foodId });
            }

            menuBiz.SaveMenu(menuDetails);
            return RedirectToAction("MenuCalendar", new { id = menu.Index });
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
