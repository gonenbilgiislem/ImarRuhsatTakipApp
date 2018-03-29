using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ImarRuhsatTakipApp.Models;

namespace ImarRuhsatTakipApp.Controllers
{
    public class Talep_TipleriController : Controller
    {
        private ImarRuhsatTakipAppDb2Entities db = new ImarRuhsatTakipAppDb2Entities();

        // GET: Talep_Tipleri
        public ActionResult Index()
        {
            return View(db.Talep_Tipleri.ToList());
        }

        // GET: Talep_Tipleri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talep_Tipleri talep_Tipleri = db.Talep_Tipleri.Find(id);
            if (talep_Tipleri == null)
            {
                return HttpNotFound();
            }
            return View(talep_Tipleri);
        }

        // GET: Talep_Tipleri/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Talep_Tipleri/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Talep_Tip_Ad")] Talep_Tipleri talep_Tipleri)
        {
            if (ModelState.IsValid)
            {
                db.Talep_Tipleri.Add(talep_Tipleri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(talep_Tipleri);
        }

        // GET: Talep_Tipleri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talep_Tipleri talep_Tipleri = db.Talep_Tipleri.Find(id);
            if (talep_Tipleri == null)
            {
                return HttpNotFound();
            }
            return View(talep_Tipleri);
        }

        // POST: Talep_Tipleri/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Talep_Tip_Ad")] Talep_Tipleri talep_Tipleri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talep_Tipleri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talep_Tipleri);
        }

        // GET: Talep_Tipleri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talep_Tipleri talep_Tipleri = db.Talep_Tipleri.Find(id);
            if (talep_Tipleri == null)
            {
                return HttpNotFound();
            }
            return View(talep_Tipleri);
        }

        // POST: Talep_Tipleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Talep_Tipleri talep_Tipleri = db.Talep_Tipleri.Find(id);
            db.Talep_Tipleri.Remove(talep_Tipleri);
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
