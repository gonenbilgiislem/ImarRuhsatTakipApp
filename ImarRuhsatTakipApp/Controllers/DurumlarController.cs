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
    public class DurumlarController : Controller
    {
        private ImarRuhsatTakipAppDb2Entities db = new ImarRuhsatTakipAppDb2Entities();

        // GET: Durumlar
        public ActionResult Index()
        {
            return View(db.Durumlar.ToList());
        }

        // GET: Durumlar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Durumlar durumlar = db.Durumlar.Find(id);
            if (durumlar == null)
            {
                return HttpNotFound();
            }
            return View(durumlar);
        }

        // GET: Durumlar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Durumlar/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Durum_Id,Durum_Aciklama")] Durumlar durumlar)
        {
            if (ModelState.IsValid)
            {
                db.Durumlar.Add(durumlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(durumlar);
        }

        // GET: Durumlar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Durumlar durumlar = db.Durumlar.Find(id);
            if (durumlar == null)
            {
                return HttpNotFound();
            }
            return View(durumlar);
        }

        // POST: Durumlar/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Durum_Id,Durum_Aciklama")] Durumlar durumlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(durumlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(durumlar);
        }

        // GET: Durumlar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Durumlar durumlar = db.Durumlar.Find(id);
            if (durumlar == null)
            {
                return HttpNotFound();
            }
            return View(durumlar);
        }

        // POST: Durumlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Durumlar durumlar = db.Durumlar.Find(id);
            db.Durumlar.Remove(durumlar);
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
