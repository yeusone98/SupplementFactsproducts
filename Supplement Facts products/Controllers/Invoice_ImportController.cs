using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Supplement_Facts_products.Models;

namespace Supplement_Facts_products.Controllers
{
    public class Invoice_ImportController : Controller
    {
        private SFP_Conncetion db = new SFP_Conncetion();

        // GET: Invoice_Import
        public ActionResult Index()
        {
            return View(db.Invoice_Import.ToList());
        }

        // GET: Invoice_Import/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice_Import invoice_Import = db.Invoice_Import.Find(id);
            if (invoice_Import == null)
            {
                return HttpNotFound();
            }
            return View(invoice_Import);
        }

        // GET: Invoice_Import/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invoice_Import/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_InvoiceImport,id_vendor,dateofImport,total")] Invoice_Import invoice_Import)
        {
            if (ModelState.IsValid)
            {
                db.Invoice_Import.Add(invoice_Import);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invoice_Import);
        }

        // GET: Invoice_Import/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice_Import invoice_Import = db.Invoice_Import.Find(id);
            if (invoice_Import == null)
            {
                return HttpNotFound();
            }
            return View(invoice_Import);
        }

        // POST: Invoice_Import/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_InvoiceImport,id_vendor,dateofImport,total")] Invoice_Import invoice_Import)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice_Import).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoice_Import);
        }

        // GET: Invoice_Import/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice_Import invoice_Import = db.Invoice_Import.Find(id);
            if (invoice_Import == null)
            {
                return HttpNotFound();
            }
            return View(invoice_Import);
        }

        // POST: Invoice_Import/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Invoice_Import invoice_Import = db.Invoice_Import.Find(id);
            db.Invoice_Import.Remove(invoice_Import);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
