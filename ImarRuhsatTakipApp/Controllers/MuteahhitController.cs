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
    public class MuteahhitController : Controller
    {
        private ImarRuhsatTakipAppDb2Entities db = new ImarRuhsatTakipAppDb2Entities();

        // GET: Muteahhit
        public ActionResult Index()
        {
            return View(db.Muteahhit.ToList());
        }

        // GET: Muteahhit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muteahhit muteahhit = db.Muteahhit.Find(id);
            if (muteahhit == null)
            {
                return HttpNotFound();
            }
            return View(muteahhit);
        }

        // GET: Muteahhit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Muteahhit/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Mutheahhit_Ad_Soyad,Mutheahhit_Firma_Adi")] Muteahhit muteahhit)
        {
            if (ModelState.IsValid)
            {
                db.Muteahhit.Add(muteahhit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(muteahhit);
        }

        // GET: Muteahhit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muteahhit muteahhit = db.Muteahhit.Find(id);
            if (muteahhit == null)
            {
                return HttpNotFound();
            }
            return View(muteahhit);
        }

        // POST: Muteahhit/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Mutheahhit_Ad_Soyad,Mutheahhit_Firma_Adi")] Muteahhit muteahhit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(muteahhit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(muteahhit);
        }

        // GET: Muteahhit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muteahhit muteahhit = db.Muteahhit.Find(id);
            if (muteahhit == null)
            {
                return HttpNotFound();
            }
            return View(muteahhit);
        }

        // POST: Muteahhit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Muteahhit muteahhit = db.Muteahhit.Find(id);
            db.Muteahhit.Remove(muteahhit);
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
