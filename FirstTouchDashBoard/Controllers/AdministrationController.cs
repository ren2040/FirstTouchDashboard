using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirstTouchDashBoard.Models;

namespace FirstTouchDashBoard.Controllers
{
    public class AdministrationController : Controller
    {
        private EDOCSIntegrationHubEntities db = new EDOCSIntegrationHubEntities();
        public AdministrationController()
        {

        }

        // GET: Administration
        public ActionResult Index()
        {
            var windowsUsername = Environment.UserName;
            ViewBag.uname = windowsUsername;
            return View(db.FirstTouchCertificateUser.ToList());
        }

        // GET: Administration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstTouchCertificateUser firstTouchCertificateUser = db.FirstTouchCertificateUser.Find(id);
            if (firstTouchCertificateUser == null)
            {
                return HttpNotFound();
            }
            return View(firstTouchCertificateUser);
        }

        // GET: Administration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,firstName,lastName,userId,email")] FirstTouchCertificateUser firstTouchCertificateUser)
        {
            if (ModelState.IsValid)
            {
                db.FirstTouchCertificateUser.Add(firstTouchCertificateUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(firstTouchCertificateUser);
        }

        // GET: Administration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstTouchCertificateUser firstTouchCertificateUser = db.FirstTouchCertificateUser.Find(id);
            if (firstTouchCertificateUser == null)
            {
                return HttpNotFound();
            }
            return View(firstTouchCertificateUser);
        }

        // POST: Administration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,firstName,lastName,userId,email")] FirstTouchCertificateUser firstTouchCertificateUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firstTouchCertificateUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(firstTouchCertificateUser);
        }

        // GET: Administration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstTouchCertificateUser firstTouchCertificateUser = db.FirstTouchCertificateUser.Find(id);
            if (firstTouchCertificateUser == null)
            {
                return HttpNotFound();
            }
            return View(firstTouchCertificateUser);
        }

        // POST: Administration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FirstTouchCertificateUser firstTouchCertificateUser = db.FirstTouchCertificateUser.Find(id);
            db.FirstTouchCertificateUser.Remove(firstTouchCertificateUser);
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
