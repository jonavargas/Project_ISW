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
    public class ProductSuppliersController : Controller
    {
        private PointSaleEntities db = new PointSaleEntities();

        //
        // GET: /ProductSuppliers/

        public ActionResult Index()
        {
            var productsuppliers = db.ProductSuppliers.Include(p => p.Products).Include(p => p.Suppliers);
            return View(productsuppliers.ToList());
        }

        //
        // GET: /ProductSuppliers/Details/5

        public ActionResult Details(int id = 0)
        {
            ProductSuppliers productsuppliers = db.ProductSuppliers.Find(id);
            if (productsuppliers == null)
            {
                return HttpNotFound();
            }
            return View(productsuppliers);
        }

        //
        // GET: /ProductSuppliers/Create

        public ActionResult Create()
        {
            ViewBag.Product = new SelectList(db.Products, "Id", "Name");
            ViewBag.Supplier = new SelectList(db.Suppliers, "Name", "Address");
            return View();
        }

        //
        // POST: /ProductSuppliers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductSuppliers productsuppliers)
        {
            if (ModelState.IsValid)
            {
                db.ProductSuppliers.Add(productsuppliers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Product = new SelectList(db.Products, "Id", "Name", productsuppliers.Product);
            ViewBag.Supplier = new SelectList(db.Suppliers, "Name", "Address", productsuppliers.Supplier);
            return View(productsuppliers);
        }

        //
        // GET: /ProductSuppliers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProductSuppliers productsuppliers = db.ProductSuppliers.Find(id);
            if (productsuppliers == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product = new SelectList(db.Products, "Id", "Name", productsuppliers.Product);
            ViewBag.Supplier = new SelectList(db.Suppliers, "Name", "Address", productsuppliers.Supplier);
            return View(productsuppliers);
        }

        //
        // POST: /ProductSuppliers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductSuppliers productsuppliers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productsuppliers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product = new SelectList(db.Products, "Id", "Name", productsuppliers.Product);
            ViewBag.Supplier = new SelectList(db.Suppliers, "Name", "Address", productsuppliers.Supplier);
            return View(productsuppliers);
        }

        //
        // GET: /ProductSuppliers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProductSuppliers productsuppliers = db.ProductSuppliers.Find(id);
            if (productsuppliers == null)
            {
                return HttpNotFound();
            }
            return View(productsuppliers);
        }

        //
        // POST: /ProductSuppliers/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSuppliers productsuppliers = db.ProductSuppliers.Find(id);
            db.ProductSuppliers.Remove(productsuppliers);
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