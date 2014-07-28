using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCompanySample.Models;
using PagedList;
using System.IO;
namespace MvcCompanySample.Controllers
{
    public class DocumentController : Controller
    {
        private MvcContextClass db = new MvcContextClass();

        //
        // GET: /Document/

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";
            if (Request.HttpMethod == "GET")
            {
                searchString = currentFilter;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter = searchString;
            var document = from d in db.Documents
                           select d;
            if (!String.IsNullOrEmpty(searchString))
            {
                document = document.Where(d => d.Company.Company_name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Date":
                    document = document.OrderBy(d => d.Document_date);
                    break;
                case "Date desc":
                    document = document.OrderByDescending(d => d.Document_date);
                    break;
                default:
                    document = document.OrderByDescending(d => d.Document_date);
                    break;
            }
            //Pager
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            //Return content
            return View(document.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Document/Create

        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Company_name");
            ViewBag.Mail_categoryID = new SelectList(db.Mail_categories, "Mail_categoryId", "Mail_category_name");
            ViewBag.Costs_groupId = new SelectList(db.Costs_groups, "Costs_groupId", "Cost_group_name");
            ViewBag.Payment_statusId = new SelectList(db.Payment_statusses, "Payment_statusId", "Payment_status_name");
            return View();
        }

        //
        // POST: /Document/Create

        [HttpPost]
        public ActionResult Create(Document document)
        {
            if (ModelState.IsValid)
            {
                db.Documents.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Company_name", document.CompanyId);
            ViewBag.Mail_categoryID = new SelectList(db.Mail_categories, "Mail_categoryId", "Mail_category_name", document.Mail_categoryID);
            ViewBag.Costs_groupId = new SelectList(db.Costs_groups, "Costs_groupId", "Cost_group_name", document.Costs_groupId);
            ViewBag.Payment_statusId = new SelectList(db.Payment_statusses, "Payment_statusId", "Payment_status_name", document.Payment_statusId);
            return View(document);
        }

        //
        // GET: /Document/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Company_name", document.CompanyId);
            ViewBag.Mail_categoryID = new SelectList(db.Mail_categories, "Mail_categoryId", "Mail_category_name", document.Mail_categoryID);
            ViewBag.Costs_groupId = new SelectList(db.Costs_groups, "Costs_groupId", "Cost_group_name", document.Costs_groupId);
            ViewBag.Payment_statusId = new SelectList(db.Payment_statusses, "Payment_statusId", "Payment_status_name", document.Payment_statusId);
            return View(document);
        }

        //
        // POST: /Document/Edit/5

        [HttpPost]
        public ActionResult Edit(Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Company_name", document.CompanyId);
            ViewBag.Mail_categoryID = new SelectList(db.Mail_categories, "Mail_categoryId", "Mail_category_name", document.Mail_categoryID);
            ViewBag.Costs_groupId = new SelectList(db.Costs_groups, "Costs_groupId", "Cost_group_name", document.Costs_groupId);
            ViewBag.Payment_statusId = new SelectList(db.Payment_statusses, "Payment_statusId", "Payment_status_name", document.Payment_statusId);
            return View(document);
        }

        //
        // GET: /Document/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        //
        // POST: /Document/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult DocumentUpload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DocumentUpload(HttpPostedFileBase file)
        {
            string path = null;
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                path = AppDomain.CurrentDomain.BaseDirectory + "Assets\\Documents\\" + fileName;
                Response.Write(path.ToString());
                file.SaveAs(path);
            }
            return RedirectToAction("Index");
        }
        public ActionResult OpenFile()
        {
            return View();
        }
    }
}