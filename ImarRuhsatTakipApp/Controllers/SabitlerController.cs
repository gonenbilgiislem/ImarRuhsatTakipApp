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
    public class SabitlerController : Controller
    {
        private ImarRuhsatTakipAppDb2Entities db = new ImarRuhsatTakipAppDb2Entities();

        // GET: Sabitler
        public ActionResult Index()
        {
            var sabitler = db.Sabitler.Include(s => s.Basvuru_Turleri);
            return View(sabitler.ToList());
        }

        // GET: Sabitler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sabitler sabitler = db.Sabitler.Find(id);
            if (sabitler == null)
            {
                return HttpNotFound();
            }
            return View(sabitler);
        }

        // GET: Sabitler/Create
        public ActionResult Create()
        {
            ViewBag.Basvuru_Turleri_Id = new SelectList(db.Basvuru_Turleri, "Id", "Basvuru_Tur_Ad");
            return View();
        }

        // POST: Sabitler/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sorular,Cevaplar,Basvuru_Turleri_Id")] Sabitler sabitler)
        {
            if (ModelState.IsValid)
            {
                db.Sabitler.Add(sabitler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Basvuru_Turleri_Id = new SelectList(db.Basvuru_Turleri, "Id", "Basvuru_Tur_Ad", sabitler.Basvuru_Turleri_Id);
            return View(sabitler);
        }

        // GET: Sabitler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sabitler sabitler = db.Sabitler.Find(id);
            if (sabitler == null)
            {
                return HttpNotFound();
            }
            ViewBag.Basvuru_Turleri_Id = new SelectList(db.Basvuru_Turleri, "Id", "Basvuru_Tur_Ad", sabitler.Basvuru_Turleri_Id);
            return View(sabitler);
        }

        // POST: Sabitler/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sorular,Cevaplar,Basvuru_Turleri_Id")] Sabitler sabitler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sabitler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Basvuru_Turleri_Id = new SelectList(db.Basvuru_Turleri, "Id", "Basvuru_Tur_Ad", sabitler.Basvuru_Turleri_Id);
            return View(sabitler);
        }

        // GET: Sabitler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sabitler sabitler = db.Sabitler.Find(id);
            if (sabitler == null)
            {
                return HttpNotFound();
            }
            return View(sabitler);
        }

        // POST: Sabitler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sabitler sabitler = db.Sabitler.Find(id);
            db.Sabitler.Remove(sabitler);
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
