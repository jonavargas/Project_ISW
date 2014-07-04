using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace MVC.Controllers
{
    public class WarehouseProductsController : Controller
    {
        private PointSaleEntities db = new PointSaleEntities();

        //
        // GET: /WarehouseProducts/

        public ActionResult Index()
        {
            var warehouseproducts = db.WarehouseProducts.Include(w => w.Products).Include(w => w.Warehouse1);
            return View(warehouseproducts.ToList());
        }

        //
        // GET: /WarehouseProducts/Details/5

        public ActionResult Details(int id = 0)
        {
            WarehouseProducts warehouseproducts = db.WarehouseProducts.Find(id);
            if (warehouseproducts == null)
            {
                return HttpNotFound();
            }
            return View(warehouseproducts);
        }

        //
        // GET: /WarehouseProducts/Create

        public ActionResult Create()
        {
            ViewBag.Product = new SelectList(db.Products, "Id", "Name");
            ViewBag.Warehouse = new SelectList(db.Warehouse, "Id", "Description");
            return View();
        }

        //
        // POST: /WarehouseProducts/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WarehouseProducts warehouseproducts)
        {
            if (ModelState.IsValid)
            {
                db.WarehouseProducts.Add(warehouseproducts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Product = new SelectList(db.Products, "Id", "Name", warehouseproducts.Product);
            ViewBag.Warehouse = new SelectList(db.Warehouse, "Id", "Description", warehouseproducts.Warehouse);
            return View(warehouseproducts);
        }

        //
        // GET: /WarehouseProducts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WarehouseProducts warehouseproducts = db.WarehouseProducts.Find(id);
            if (warehouseproducts == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product = new SelectList(db.Products, "Id", "Name", warehouseproducts.Product);
            ViewBag.Warehouse = new SelectList(db.Warehouse, "Id", "Description", warehouseproducts.Warehouse);
            return View(warehouseproducts);
        }

        //
        // POST: /WarehouseProducts/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WarehouseProducts warehouseproducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warehouseproducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product = new SelectList(db.Products, "Id", "Name", warehouseproducts.Product);
            ViewBag.Warehouse = new SelectList(db.Warehouse, "Id", "Description", warehouseproducts.Warehouse);
            return View(warehouseproducts);
        }

        //
        // GET: /WarehouseProducts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WarehouseProducts warehouseproducts = db.WarehouseProducts.Find(id);
            if (warehouseproducts == null)
            {
                return HttpNotFound();
            }
            return View(warehouseproducts);
        }

        //
        // POST: /WarehouseProducts/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WarehouseProducts warehouseproducts = db.WarehouseProducts.Find(id);
            db.WarehouseProducts.Remove(warehouseproducts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}