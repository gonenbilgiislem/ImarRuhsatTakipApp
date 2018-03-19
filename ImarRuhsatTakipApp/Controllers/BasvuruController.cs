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
    public class BasvuruController : Controller
    {
        private ImarRuhsatTakipAppDb2Entities db = new ImarRuhsatTakipAppDb2Entities();

        // GET: Basvuru
        public ActionResult Index()
        {
            var basvuru = db.Basvuru.Include(b => b.Basvuru_Turleri).Include(b => b.Durumlar).Include(b => b.Kullanicilar).Include(b => b.Muteahhit).Include(b => b.Talep_Tipleri).Include(b => b.Yapi_Denetim_Firmasi);
            return View(basvuru.ToList());
        }

        // GET: Basvuru/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basvuru basvuru = db.Basvuru.Find(id);
            if (basvuru == null)
            {
                return HttpNotFound();
            }
            return View(basvuru);
        }

        // GET: Basvuru/Create
        public ActionResult Create()
        {
            ViewBag.Basvuru_Turleri_Id = new SelectList(db.Basvuru_Turleri, "Id", "Basvuru_Tur_Ad");
            ViewBag.Durum_Id = new SelectList(db.Durumlar, "Id", "Durum_Aciklama");
            ViewBag.Kullanicilar_Id = new SelectList(db.Kullanicilar, "Id", "Kullanici_Ad_Soyad");
            ViewBag.Muteahhit_Id = new SelectList(db.Muteahhit, "Id", "Mutheahhit_Ad_Soyad");
            ViewBag.Talep_Tipleri_Id = new SelectList(db.Talep_Tipleri, "Id", "Talep_Tip_Ad");
            ViewBag.Yapi_Denetim_Firmasi_Id = new SelectList(db.Yapi_Denetim_Firmasi, "Id", "Yapi_Denetim_Adi");
            return View();
        }

        // POST: Basvuru/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Basvuru_Turleri_Id,Referans_kod,Mal_Sahibi_Ad_Soyad,Yapi_Denetim_Firmasi_Id,Muteahhit_Id,Talep_Tipleri_Id,Durum_Id,Aciklama,Kullanicilar_Id,Dilekce_Tarihi")] Basvuru basvuru)
        {
            if (ModelState.IsValid)
            {
                db.Basvuru.Add(basvuru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Basvuru_Turleri_Id = new SelectList(db.Basvuru_Turleri, "Id", "Basvuru_Tur_Ad", basvuru.Basvuru_Turleri_Id);
            ViewBag.Durum_Id = new SelectList(db.Durumlar, "Id", "Durum_Aciklama", basvuru.Durum_Id);
            ViewBag.Kullanicilar_Id = new SelectList(db.Kullanicilar, "Id", "Kullanici_Ad_Soyad", basvuru.Kullanicilar_Id);
            ViewBag.Muteahhit_Id = new SelectList(db.Muteahhit, "Id", "Mutheahhit_Ad_Soyad", basvuru.Muteahhit_Id);
            ViewBag.Talep_Tipleri_Id = new SelectList(db.Talep_Tipleri, "Id", "Talep_Tip_Ad", basvuru.Talep_Tipleri_Id);
            ViewBag.Yapi_Denetim_Firmasi_Id = new SelectList(db.Yapi_Denetim_Firmasi, "Id", "Yapi_Denetim_Adi", basvuru.Yapi_Denetim_Firmasi_Id);
            return View(basvuru);
        }

        // GET: Basvuru/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basvuru basvuru = db.Basvuru.Find(id);
            if (basvuru == null)
            {
                return HttpNotFound();
            }
            ViewBag.Basvuru_Turleri_Id = new SelectList(db.Basvuru_Turleri, "Id", "Basvuru_Tur_Ad", basvuru.Basvuru_Turleri_Id);
            ViewBag.Durum_Id = new SelectList(db.Durumlar, "Id", "Durum_Aciklama", basvuru.Durum_Id);
            ViewBag.Kullanicilar_Id = new SelectList(db.Kullanicilar, "Id", "Kullanici_Ad_Soyad", basvuru.Kullanicilar_Id);
            ViewBag.Muteahhit_Id = new SelectList(db.Muteahhit, "Id", "Mutheahhit_Ad_Soyad", basvuru.Muteahhit_Id);
            ViewBag.Talep_Tipleri_Id = new SelectList(db.Talep_Tipleri, "Id", "Talep_Tip_Ad", basvuru.Talep_Tipleri_Id);
            ViewBag.Yapi_Denetim_Firmasi_Id = new SelectList(db.Yapi_Denetim_Firmasi, "Id", "Yapi_Denetim_Adi", basvuru.Yapi_Denetim_Firmasi_Id);
            return View(basvuru);
        }

        // POST: Basvuru/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Basvuru_Turleri_Id,Referans_kod,Mal_Sahibi_Ad_Soyad,Yapi_Denetim_Firmasi_Id,Muteahhit_Id,Talep_Tipleri_Id,Durum_Id,Aciklama,Kullanicilar_Id,Dilekce_Tarihi")] Basvuru basvuru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basvuru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Basvuru_Turleri_Id = new SelectList(db.Basvuru_Turleri, "Id", "Basvuru_Tur_Ad", basvuru.Basvuru_Turleri_Id);
            ViewBag.Durum_Id = new SelectList(db.Durumlar, "Id", "Durum_Aciklama", basvuru.Durum_Id);
            ViewBag.Kullanicilar_Id = new SelectList(db.Kullanicilar, "Id", "Kullanici_Ad_Soyad", basvuru.Kullanicilar_Id);
            ViewBag.Muteahhit_Id = new SelectList(db.Muteahhit, "Id", "Mutheahhit_Ad_Soyad", basvuru.Muteahhit_Id);
            ViewBag.Talep_Tipleri_Id = new SelectList(db.Talep_Tipleri, "Id", "Talep_Tip_Ad", basvuru.Talep_Tipleri_Id);
            ViewBag.Yapi_Denetim_Firmasi_Id = new SelectList(db.Yapi_Denetim_Firmasi, "Id", "Yapi_Denetim_Adi", basvuru.Yapi_Denetim_Firmasi_Id);
            return View(basvuru);
        }

        // GET: Basvuru/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basvuru basvuru = db.Basvuru.Find(id);
            if (basvuru == null)
            {
                return HttpNotFound();
            }
            return View(basvuru);
        }

        // POST: Basvuru/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Basvuru basvuru = db.Basvuru.Find(id);
            db.Basvuru.Remove(basvuru);
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
