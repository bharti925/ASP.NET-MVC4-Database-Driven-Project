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
    public class FunctionController : Controller
    {
        private MvcContextClass db = new MvcContextClass();

        //
        // GET: /Function/

        public ActionResult Index()
        {
            return View(db.Functions.ToList());
        }

        //
        // GET: /Function/Details/5

        public ActionResult Details(int id = 0)
        {
            Function function = db.Functions.Find(id);
            if (function == null)
            {
                return HttpNotFound();
            }
            return View(function);
        }

        //
        // GET: /Function/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Function/Create

        [HttpPost]
        public ActionResult Create(Function function)
        {
            if (ModelState.IsValid)
            {
                db.Functions.Add(function);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(function);
        }

        //
        // GET: /Function/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Function function = db.Functions.Find(id);
            if (function == null)
            {
                return HttpNotFound();
            }
            return View(function);
        }

        //
        // POST: /Function/Edit/5

        [HttpPost]
        public ActionResult Edit(Function function)
        {
            if (ModelState.IsValid)
            {
                db.Entry(function).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(function);
        }

        //
        // GET: /Function/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Function function = db.Functions.Find(id);
            if (function == null)
            {
                return HttpNotFound();
            }
            return View(function);
        }

        //
        // POST: /Function/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Function function = db.Functions.Find(id);
            db.Functions.Remove(function);
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