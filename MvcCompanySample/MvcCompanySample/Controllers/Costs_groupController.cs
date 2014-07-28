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
    public class Costs_groupController : Controller
    {
        private MvcContextClass db = new MvcContextClass();

        //
        // GET: /Costs_group/

        public ActionResult Index()
        {
            return View(db.Costs_groups.ToList());
        }

        //
        // GET: /Costs_group/Details/5

        public ActionResult Details(int id = 0)
        {
            Costs_group costs_group = db.Costs_groups.Find(id);
            if (costs_group == null)
            {
                return HttpNotFound();
            }
            return View(costs_group);
        }

        //
        // GET: /Costs_group/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Costs_group/Create

        [HttpPost]
        public ActionResult Create(Costs_group costs_group)
        {
            if (ModelState.IsValid)
            {
                db.Costs_groups.Add(costs_group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(costs_group);
        }

        //
        // GET: /Costs_group/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Costs_group costs_group = db.Costs_groups.Find(id);
            if (costs_group == null)
            {
                return HttpNotFound();
            }
            return View(costs_group);
        }

        //
        // POST: /Costs_group/Edit/5

        [HttpPost]
        public ActionResult Edit(Costs_group costs_group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(costs_group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(costs_group);
        }

        //
        // GET: /Costs_group/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Costs_group costs_group = db.Costs_groups.Find(id);
            if (costs_group == null)
            {
                return HttpNotFound();
            }
            return View(costs_group);
        }

        //
        // POST: /Costs_group/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Costs_group costs_group = db.Costs_groups.Find(id);
            db.Costs_groups.Remove(costs_group);
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