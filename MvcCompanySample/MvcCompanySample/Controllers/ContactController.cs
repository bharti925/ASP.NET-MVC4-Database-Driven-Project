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
    public class ContactController : Controller
    {
        private MvcContextClass db = new MvcContextClass();

        //
        // GET: /Contact/

        public ActionResult Index()
        {
            var contacts = db.Contacts.Include(c => c.Company).Include(c => c.Function).Include(c => c.Title);
            return View(contacts.ToList());
        }

        //
        // GET: /Contact/Details/5

        public ActionResult Details(int id = 0)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Company_name");
            ViewBag.FunctionId = new SelectList(db.Functions, "FunctionId", "Function_name");
            ViewBag.TitleId = new SelectList(db.Titles, "TitleId", "Title_name");
            return View();
        }

        //
        // POST: /Contact/Create

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Company_name", contact.CompanyId);
            ViewBag.FunctionId = new SelectList(db.Functions, "FunctionId", "Function_name", contact.FunctionId);
            ViewBag.TitleId = new SelectList(db.Titles, "TitleId", "Title_name", contact.TitleId);
            return View(contact);
        }

        //
        // GET: /Contact/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Company_name", contact.CompanyId);
            ViewBag.FunctionId = new SelectList(db.Functions, "FunctionId", "Function_name", contact.FunctionId);
            ViewBag.TitleId = new SelectList(db.Titles, "TitleId", "Title_name", contact.TitleId);
            return View(contact);
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Company_name", contact.CompanyId);
            ViewBag.FunctionId = new SelectList(db.Functions, "FunctionId", "Function_name", contact.FunctionId);
            ViewBag.TitleId = new SelectList(db.Titles, "TitleId", "Title_name", contact.TitleId);
            return View(contact);
        }

        //
        // GET: /Contact/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contact/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
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