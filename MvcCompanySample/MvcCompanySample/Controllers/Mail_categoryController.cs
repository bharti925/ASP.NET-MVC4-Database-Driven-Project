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
    public class Mail_categoryController : Controller
    {
        private MvcContextClass db = new MvcContextClass();

        //
        // GET: /Mail_category/

        public ActionResult Index()
        {
            return View(db.Mail_categories.ToList());
        }

        //
        // GET: /Mail_category/Details/5

        public ActionResult Details(int id = 0)
        {
            Mail_category mail_category = db.Mail_categories.Find(id);
            if (mail_category == null)
            {
                return HttpNotFound();
            }
            return View(mail_category);
        }

        //
        // GET: /Mail_category/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Mail_category/Create

        [HttpPost]
        public ActionResult Create(Mail_category mail_category)
        {
            if (ModelState.IsValid)
            {
                db.Mail_categories.Add(mail_category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mail_category);
        }

        //
        // GET: /Mail_category/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Mail_category mail_category = db.Mail_categories.Find(id);
            if (mail_category == null)
            {
                return HttpNotFound();
            }
            return View(mail_category);
        }

        //
        // POST: /Mail_category/Edit/5

        [HttpPost]
        public ActionResult Edit(Mail_category mail_category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mail_category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mail_category);
        }

        //
        // GET: /Mail_category/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Mail_category mail_category = db.Mail_categories.Find(id);
            if (mail_category == null)
            {
                return HttpNotFound();
            }
            return View(mail_category);
        }

        //
        // POST: /Mail_category/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Mail_category mail_category = db.Mail_categories.Find(id);
            db.Mail_categories.Remove(mail_category);
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