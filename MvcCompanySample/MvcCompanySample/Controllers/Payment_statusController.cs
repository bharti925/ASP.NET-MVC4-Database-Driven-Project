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
    public class Payment_statusController : Controller
    {
        private MvcContextClass db = new MvcContextClass();

        //
        // GET: /Payment_status/

        public ActionResult Index()
        {
            return View(db.Payment_statusses.ToList());
        }

        //
        // GET: /Payment_status/Details/5

        public ActionResult Details(int id = 0)
        {
            Payment_status payment_status = db.Payment_statusses.Find(id);
            if (payment_status == null)
            {
                return HttpNotFound();
            }
            return View(payment_status);
        }

        //
        // GET: /Payment_status/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Payment_status/Create

        [HttpPost]
        public ActionResult Create(Payment_status payment_status)
        {
            if (ModelState.IsValid)
            {
                db.Payment_statusses.Add(payment_status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(payment_status);
        }

        //
        // GET: /Payment_status/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Payment_status payment_status = db.Payment_statusses.Find(id);
            if (payment_status == null)
            {
                return HttpNotFound();
            }
            return View(payment_status);
        }

        //
        // POST: /Payment_status/Edit/5

        [HttpPost]
        public ActionResult Edit(Payment_status payment_status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment_status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payment_status);
        }

        //
        // GET: /Payment_status/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Payment_status payment_status = db.Payment_statusses.Find(id);
            if (payment_status == null)
            {
                return HttpNotFound();
            }
            return View(payment_status);
        }

        //
        // POST: /Payment_status/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment_status payment_status = db.Payment_statusses.Find(id);
            db.Payment_statusses.Remove(payment_status);
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