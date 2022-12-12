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
    public class DETAILS_IMPORTController : Controller
    {
        private SFP_Conncetion db = new SFP_Conncetion();

        // GET: DETAILS_IMPORT
        public ActionResult Index()
        {
            return View(db.DETAILS_IMPORT.ToList());
        }

        // GET: DETAILS_IMPORT/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETAILS_IMPORT dETAILS_IMPORT = db.DETAILS_IMPORT.Find(id);
            if (dETAILS_IMPORT == null)
            {
                return HttpNotFound();
            }
            return View(dETAILS_IMPORT);
        }

        // GET: DETAILS_IMPORT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DETAILS_IMPORT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_InvoiceImport,id_Product,numberOf_Product,intomoney,importUnit_Price")] DETAILS_IMPORT dETAILS_IMPORT)
        {
            if (ModelState.IsValid)
            {
                db.DETAILS_IMPORT.Add(dETAILS_IMPORT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dETAILS_IMPORT);
        }

        // GET: DETAILS_IMPORT/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETAILS_IMPORT dETAILS_IMPORT = db.DETAILS_IMPORT.Find(id);
            if (dETAILS_IMPORT == null)
            {
                return HttpNotFound();
            }
            return View(dETAILS_IMPORT);
        }

        // POST: DETAILS_IMPORT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_InvoiceImport,id_Product,numberOf_Product,intomoney,importUnit_Price")] DETAILS_IMPORT dETAILS_IMPORT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETAILS_IMPORT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dETAILS_IMPORT);
        }

        // GET: DETAILS_IMPORT/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETAILS_IMPORT dETAILS_IMPORT = db.DETAILS_IMPORT.Find(id);
            if (dETAILS_IMPORT == null)
            {
                return HttpNotFound();
            }
            return View(dETAILS_IMPORT);
        }

        // POST: DETAILS_IMPORT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DETAILS_IMPORT dETAILS_IMPORT = db.DETAILS_IMPORT.Find(id);
            db.DETAILS_IMPORT.Remove(dETAILS_IMPORT);
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
