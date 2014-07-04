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
    public class UsersController : Controller
    {
        private PointSaleEntities db = new PointSaleEntities();

        //
        // GET: /Users/

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id = 0)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Users/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login (Users u){
            //this action is for handle post (login)

            if(ModelState.IsValid){//this is check validity

                using(PointSaleEntities dc= new PointSaleEntities()){
                            
                            var v= dc.Users.Where(a=>a.Nickname.Equals(u.Nickname)&& a.Password.Equals(u.Password)).FirstOrDefault();
                            if(v!=null){
                               Session["LogedUserID"]=v.Id.ToString();
                               Session["LogedUserNickname"]=v.Nickname.ToString(); 
                               return RedirectToAction("AfterLogin");   
                            }
                     }
            }
            return View(u);
        }


        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"]!=null)
            {
                return View();
            }
            else
            {
                return RedirectToRoute("index","Main");
            }


           
        }


        //
        // GET: /Users/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
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