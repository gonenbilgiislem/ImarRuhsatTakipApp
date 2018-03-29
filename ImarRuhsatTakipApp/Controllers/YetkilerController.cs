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
    public class YetkilerController : Controller
    {
        private ImarRuhsatTakipAppDb2Entities db = new ImarRuhsatTakipAppDb2Entities();

        // GET: Yetkiler
        public ActionResult Index()
        {
            var yetkiler = db.Yetkiler.Include(y => y.Basvuru_Turleri).Include(y => y.Kullanicilar);
            return View(yetkiler.ToList());
        }

        // GET: Yetkiler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yetkiler yetkiler = db.Yetkiler.Find(id);
            if (yetkiler == null)
            {
                return HttpNotFound();
            }
            return View(yetkiler);
        }

        // GET: Yetkiler/Create
        public ActionResult Create()
        {
            ViewBag.Basvuru_Turleri_Id = new SelectList(db.Basvuru_Turleri, "Id", "Basvuru_Tur_Ad");
            ViewBag.Kullanicilar_Id = new SelectList(db.Kullanicilar, "Id", "Kullanici_Ad_Soyad");
            return View();
        }

        // POST: Yetkiler/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Kullanicilar_Id,Basvuru_Turleri_Id")] Yetkiler yetkiler)
        {
            if (ModelState.IsValid)
            {
                db.Yetkiler.Add(yetkiler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Basvuru_Turleri_Id = new SelectList(db.Basvuru_Turleri, "Id", "Basvuru_Tur_Ad", yetkiler.Basvuru_Turleri_Id);
            ViewBag.Kullanicilar_Id = new SelectList(db.Kullanicilar, "Id", "Kullanici_Ad_Soyad", yetkiler.Kullanicilar_Id);
            return View(yetkiler);
        }

        // GET: Yetkiler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yetkiler yetkiler = db.Yetkiler.Find(id);
            if (yetkiler == null)
            {
                return HttpNotFound();
            }
            ViewBag.Basvuru_Turleri_Id = new SelectList(db.Basvuru_Turleri, "Id", "Basvuru_Tur_Ad", yetkiler.Basvuru_Turleri_Id);
            ViewBag.Kullanicilar_Id = new SelectList(db.Kullanicilar, "Id", "Kullanici_Ad_Soyad", yetkiler.Kullanicilar_Id);
            return View(yetkiler);
        }

        // POST: Yetkiler/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Kullanicilar_Id,Basvuru_Turleri_Id")] Yetkiler yetkiler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yetkiler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Basvuru_Turleri_Id = new SelectList(db.Basvuru_Turleri, "Id", "Basvuru_Tur_Ad", yetkiler.Basvuru_Turleri_Id);
            ViewBag.Kullanicilar_Id = new SelectList(db.Kullanicilar, "Id", "Kullanici_Ad_Soyad", yetkiler.Kullanicilar_Id);
            return View(yetkiler);
        }

        // GET: Yetkiler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yetkiler yetkiler = db.Yetkiler.Find(id);
            if (yetkiler == null)
            {
                return HttpNotFound();
            }
            return View(yetkiler);
        }

        // POST: Yetkiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yetkiler yetkiler = db.Yetkiler.Find(id);
            db.Yetkiler.Remove(yetkiler);
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
