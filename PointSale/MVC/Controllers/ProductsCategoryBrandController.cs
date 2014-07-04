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
    public class ProductsCategoryBrandController : Controller
    {
        private PointSaleEntities db = new PointSaleEntities();

        //
        // GET: /ProductsCategoryBrand/

        public ActionResult Index()
        {
            var productscategorybrand = db.ProductsCategoryBrand.Include(p => p.Brand1).Include(p => p.Category1).Include(p => p.Products);
            return View(productscategorybrand.ToList());
        }

        //
        // GET: /ProductsCategoryBrand/Details/5

        public ActionResult Details(int id = 0)
        {
            ProductsCategoryBrand productscategorybrand = db.ProductsCategoryBrand.Find(id);
            if (productscategorybrand == null)
            {
                return HttpNotFound();
            }
            return View(productscategorybrand);
        }

        //
        // GET: /ProductsCategoryBrand/Create

        public ActionResult Create()
        {
            ViewBag.Brand = new SelectList(db.Brand, "Name", "Name");
            ViewBag.Category = new SelectList(db.Category, "Name", "Description");
            ViewBag.Product = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        //
        // POST: /ProductsCategoryBrand/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductsCategoryBrand productscategorybrand)
        {
            if (ModelState.IsValid)
            {
                db.ProductsCategoryBrand.Add(productscategorybrand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Brand = new SelectList(db.Brand, "Name", "Name", productscategorybrand.Brand);
            ViewBag.Category = new SelectList(db.Category, "Name", "Description", productscategorybrand.Category);
            ViewBag.Product = new SelectList(db.Products, "Id", "Name", productscategorybrand.Product);
            return View(productscategorybrand);
        }

        //
        // GET: /ProductsCategoryBrand/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProductsCategoryBrand productscategorybrand = db.ProductsCategoryBrand.Find(id);
            if (productscategorybrand == null)
            {
                return HttpNotFound();
            }
            ViewBag.Brand = new SelectList(db.Brand, "Name", "Name", productscategorybrand.Brand);
            ViewBag.Category = new SelectList(db.Category, "Name", "Description", productscategorybrand.Category);
            ViewBag.Product = new SelectList(db.Products, "Id", "Name", productscategorybrand.Product);
            return View(productscategorybrand);
        }

        //
        // POST: /ProductsCategoryBrand/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductsCategoryBrand productscategorybrand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productscategorybrand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Brand = new SelectList(db.Brand, "Name", "Name", productscategorybrand.Brand);
            ViewBag.Category = new SelectList(db.Category, "Name", "Description", productscategorybrand.Category);
            ViewBag.Product = new SelectList(db.Products, "Id", "Name", productscategorybrand.Product);
            return View(productscategorybrand);
        }

        //
        // GET: /ProductsCategoryBrand/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProductsCategoryBrand productscategorybrand = db.ProductsCategoryBrand.Find(id);
            if (productscategorybrand == null)
            {
                return HttpNotFound();
            }
            return View(productscategorybrand);
        }

        //
        // POST: /ProductsCategoryBrand/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductsCategoryBrand productscategorybrand = db.ProductsCategoryBrand.Find(id);
            db.ProductsCategoryBrand.Remove(productscategorybrand);
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