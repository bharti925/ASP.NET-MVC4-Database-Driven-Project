using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCompanySample.Models;

namespace MvcCompanySample.Controllers
{
    public class TitleController : Controller
    {
        private MvcContextClass db = new MvcContextClass();

        //
        // GET: /Title/

        public ActionResult Index()
        {
            return View(db.Titles.ToList());
        }

        //
        // GET: /Title/Details/5

        public ActionResult Details(int id = 0)
        {
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        //
        // GET: /Title/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Title/Create

        [HttpPost]
        public ActionResult Create(Title title)
        {
            if (ModelState.IsValid)
            {
                db.Titles.Add(title);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(title);
        }

        //
        // GET: /Title/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        //
        // POST: /Title/Edit/5

        [HttpPost]
        public ActionResult Edit(Title title)
        {
            if (ModelState.IsValid)
            {
                db.Entry(title).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(title);
        }

        //
        // GET: /Title/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        //
        // POST: /Title/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Title title = db.Titles.Find(id);
            db.Titles.Remove(title);
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