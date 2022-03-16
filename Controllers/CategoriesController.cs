using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompShop2.Models;

namespace CompShop2.Controllers
{
    public class CategoriesController : Controller
    {
        private DBShopEntities db = new DBShopEntities();
        [Authorize(Roles = "Seller,Manager")]
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        [Authorize(Roles = "Seller,Manager")]
        // GET: Categorys/Details/5
        public ActionResult Details(int id)
        {
            Categories categorys = db.Categories.Find(id);
            if (categorys == null)
            {
                return HttpNotFound();
            }
            return View(categorys);
        }

      
        // GET: Categorys/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Manager")]
        // POST: Categorys/Create
        [HttpPost]
        public ActionResult Create(Categories categorys)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(categorys);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorys);
        }

        [Authorize(Roles = "Manager")]
        // GET: Categorys/Edit/5
        public ActionResult Edit(int id=0)
        {
            Categories categorys = db.Categories.Find(id);
            if (categorys == null)
            {
                return HttpNotFound();
            }
            return View(categorys);
        }
        
        [HttpPost]
        public ActionResult Edit(Categories categorys)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorys).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorys);
        }

        [Authorize(Roles = "Manager")]
        // GET: Categorys/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Categories categorys = db.Categories.Find(id);
            if (categorys == null)
            {
                return HttpNotFound();
            }
            return View(categorys);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Categories.Remove(db.Categories.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
