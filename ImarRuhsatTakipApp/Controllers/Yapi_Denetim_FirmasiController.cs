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
    public class Yapi_Denetim_FirmasiController : Controller
    {
        private ImarRuhsatTakipAppDb2Entities db = new ImarRuhsatTakipAppDb2Entities();

        // GET: Yapi_Denetim_Firmasi
        public ActionResult Index()
        {
            return View(db.Yapi_Denetim_Firmasi.ToList());
        }

        // GET: Yapi_Denetim_Firmasi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yapi_Denetim_Firmasi yapi_Denetim_Firmasi = db.Yapi_Denetim_Firmasi.Find(id);
            if (yapi_Denetim_Firmasi == null)
            {
                return HttpNotFound();
            }
            return View(yapi_Denetim_Firmasi);
        }

        // GET: Yapi_Denetim_Firmasi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yapi_Denetim_Firmasi/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Yapi_Denetim_Adi")] Yapi_Denetim_Firmasi yapi_Denetim_Firmasi)
        {
            if (ModelState.IsValid)
            {
                db.Yapi_Denetim_Firmasi.Add(yapi_Denetim_Firmasi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yapi_Denetim_Firmasi);
        }

        // GET: Yapi_Denetim_Firmasi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yapi_Denetim_Firmasi yapi_Denetim_Firmasi = db.Yapi_Denetim_Firmasi.Find(id);
            if (yapi_Denetim_Firmasi == null)
            {
                return HttpNotFound();
            }
            return View(yapi_Denetim_Firmasi);
        }

        // POST: Yapi_Denetim_Firmasi/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Yapi_Denetim_Adi")] Yapi_Denetim_Firmasi yapi_Denetim_Firmasi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yapi_Denetim_Firmasi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yapi_Denetim_Firmasi);
        }

        // GET: Yapi_Denetim_Firmasi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yapi_Denetim_Firmasi yapi_Denetim_Firmasi = db.Yapi_Denetim_Firmasi.Find(id);
            if (yapi_Denetim_Firmasi == null)
            {
                return HttpNotFound();
            }
            return View(yapi_Denetim_Firmasi);
        }

        // POST: Yapi_Denetim_Firmasi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yapi_Denetim_Firmasi yapi_Denetim_Firmasi = db.Yapi_Denetim_Firmasi.Find(id);
            db.Yapi_Denetim_Firmasi.Remove(yapi_Denetim_Firmasi);
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
