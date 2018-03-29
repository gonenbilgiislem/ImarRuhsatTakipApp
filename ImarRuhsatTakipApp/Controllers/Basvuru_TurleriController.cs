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
    public class Basvuru_TurleriController : Controller
    {
        private ImarRuhsatTakipAppDb2Entities db = new ImarRuhsatTakipAppDb2Entities();

        // GET: Basvuru_Turleri
        public ActionResult Index()
        {
            return View(db.Basvuru_Turleri.ToList());
        }

        // GET: Basvuru_Turleri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basvuru_Turleri basvuru_Turleri = db.Basvuru_Turleri.Find(id);
            if (basvuru_Turleri == null)
            {
                return HttpNotFound();
            }
            return View(basvuru_Turleri);
        }

        // GET: Basvuru_Turleri/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Basvuru_Turleri/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Basvuru_Tur_Ad")] Basvuru_Turleri basvuru_Turleri)
        {
            if (ModelState.IsValid)
            {
                db.Basvuru_Turleri.Add(basvuru_Turleri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(basvuru_Turleri);
        }

        // GET: Basvuru_Turleri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basvuru_Turleri basvuru_Turleri = db.Basvuru_Turleri.Find(id);
            if (basvuru_Turleri == null)
            {
                return HttpNotFound();
            }
            return View(basvuru_Turleri);
        }

        // POST: Basvuru_Turleri/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Basvuru_Tur_Ad")] Basvuru_Turleri basvuru_Turleri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basvuru_Turleri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(basvuru_Turleri);
        }

        // GET: Basvuru_Turleri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basvuru_Turleri basvuru_Turleri = db.Basvuru_Turleri.Find(id);
            if (basvuru_Turleri == null)
            {
                return HttpNotFound();
            }
            return View(basvuru_Turleri);
        }

        // POST: Basvuru_Turleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Basvuru_Turleri basvuru_Turleri = db.Basvuru_Turleri.Find(id);
            db.Basvuru_Turleri.Remove(basvuru_Turleri);
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
