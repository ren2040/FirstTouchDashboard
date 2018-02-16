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
    public class CertificatesController : Controller
    {
        private EDOCSIntegrationHubEntities db = new EDOCSIntegrationHubEntities();

        // GET: Certificates
        [HttpGet]
        public ActionResult Index(string SortOrder)
        {

            var mod = new ExtendedCertificates();
            mod.lCertificates = db.FirstTouchCertificates.ToList();

            if (mod.from != null)
            {
                mod.lCertificates = mod.lCertificates.Where(m => m.datetime > mod.from).ToList();
            }
            if(mod.to != null)
            {
                mod.lCertificates = mod.lCertificates.Where(m => m.datetime < mod.to).ToList();
            }
            if(!string.IsNullOrEmpty(mod.postCode))
            {
                mod.lCertificates = mod.lCertificates.Where(m => m.postcode.Contains(m.postcode)).ToList();
            }
            if(!string.IsNullOrEmpty(mod.propertyid))
            {
                mod.lCertificates = mod.lCertificates.Where(m => m.propertyid.Contains(m.propertyid)).ToList();
            }
            if(!string.IsNullOrEmpty(mod.uprn))
            {
                    mod.lCertificates = mod.lCertificates.Where(m => m.uprn.Contains(mod.uprn)).ToList();
            }
            if(mod.certType != null)
            {
                if (mod.certType.ToLower().Equals("both"))
                {

                }
                else
                {
                    mod.lCertificates = mod.lCertificates.Where(m => m.certtype.Contains(m.certtype)).ToList();
                }
            }

                ViewBag.propertyid = String.IsNullOrEmpty(SortOrder) ? "propertyid_desc" : "";
                ViewBag.uprn = SortOrder == "uprn" ? "uprn_desc" : "uprn";
                ViewBag.addressline1 = SortOrder == "addressline1" ? "addressline1_desc" : "addressline1";
                ViewBag.certtype = SortOrder == "certtype" ? "certtype_desc" : "certtype";
                ViewBag.postcode = SortOrder == "postcode" ? "postcode_desc" : "postcode";
                ViewBag.operativename = SortOrder == "operativename" ? "operativename_desc" : "operativename";
                ViewBag.tradegroup = SortOrder == "tradegroup" ? "tradegroup_desc" : "tradegroup";
                ViewBag.eDocsRef = SortOrder == "eDocsRef" ? "eDocsRef_desc" : "eDocsRef";
                ViewBag.status = SortOrder == "status" ? "status_desc" : "status";
                ViewBag.datetime = SortOrder == "datetime" ? "datetime_desc" : "datetime";
                ViewBag.cause = SortOrder == "cause" ? "cause_desc" : "cause";

                var emp = from s in db.FirstTouchCertificates
                          select s;


            if (!string.IsNullOrEmpty(SortOrder))
            {
                switch (SortOrder)
                {
                    case "propertyid_desc":

                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderByDescending(s => s.propertyid).ToList();
                       
                        break;
                    case "uprn_desc":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderByDescending(s => s.uprn).ToList();
                        break;
                    case "uprn":
                        emp = emp.OrderBy(s => s.uprn);
                        break;
                    case "addressline1_desc":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderByDescending(s => s.addressline1).ToList();
                        break;
                    case "addressline1":
                        emp = emp.OrderBy(s => s.addressline1);
                        break;
                    case "certtype_desc":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderByDescending(s => s.certtype).ToList();
                        break;
                    case "certtype":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderBy(s => s.certtype).ToList();
                        break;
                    case "postcode":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderBy(s => s.postcode).ToList();
                        break;
                    case "operativename":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderBy(s => s.operativename).ToList();
                        break;
                    case "tradegroup":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderBy(s => s.tradegroup).ToList();
                        break;
                    case "eDocsRef":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderBy(s => s.eDocsRef).ToList();
                        break;
                    case "status":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderBy(s => s.status).ToList();
                        break;
                    case "datetime":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderBy(s => s.datetime).ToList();
                        break;
                    case "cause":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderBy(s => s.cause).ToList();
                        break;
                    case "postcode_desc":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderByDescending(s => s.postcode).ToList(); ;
                        break;
                    case "operativename_desc":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderByDescending(s => s.operativename).ToList();
                        break;
                    case "tradegroup_desc":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderByDescending(s => s.tradegroup).ToList();
                        break;
                    case "eDocsRef_desc":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderByDescending(s => s.eDocsRef).ToList();
                        break;
                    case "status_desc":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderByDescending(s => s.status).ToList();
                        break;
                    case "datetime_desc":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderByDescending(s => s.datetime).ToList();
                        break;
                    case "cause_desc":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderByDescending(s => s.cause).ToList();
                        break;
                    default:
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderBy(s => s.propertyid).ToList();
                        break;
                }
            }
                return View(mod);
        }




        // GET: Certificates
        [HttpPost]
        public ActionResult Index(string SortOrder, ExtendedCertificates model)
        {
            model.lCertificates = db.FirstTouchCertificates.ToList();

            if (model.from != null)
            {
                model.lCertificates = model.lCertificates.Where(m => m.datetime > model.from).ToList();
            }
            if (model.to != null)
            {
                model.lCertificates = model.lCertificates.Where(m => m.datetime < model.to).ToList();
            }
            if (!string.IsNullOrEmpty(model.postCode))
            {
                model.lCertificates = model.lCertificates.Where(m => m.postcode != null).ToList();
                model.lCertificates = model.lCertificates.Where(m => m.postcode.Contains(model.postCode)).ToList();
            }
            if (model.propertyid != null)
            {
                model.lCertificates = model.lCertificates.Where(m => m.propertyid != null).ToList();
                model.lCertificates = model.lCertificates.Where(m => m.propertyid.Contains(model.propertyid)).ToList();
            }
            if (!string.IsNullOrEmpty(model.uprn))
            {
                model.lCertificates = model.lCertificates.Where(m => m.uprn != null).ToList();
                model.lCertificates = model.lCertificates.Where(m => m.uprn.Contains(model.uprn)).ToList();
            }
            if (model.certType != null)
            {
                if (model.certType.ToLower().Equals("both"))
                {

                }
                else
                {
                    model.lCertificates = model.lCertificates.Where(m => m.certtype != null).ToList();
                    model.lCertificates = model.lCertificates.Where(m => m.certtype.Contains(model.certType)).ToList();
                }
            }

            ViewBag.propertyid = String.IsNullOrEmpty(SortOrder) ? "propertyid_desc" : "";
            ViewBag.uprn = SortOrder == "uprn" ? "uprn_desc" : "uprn";
            ViewBag.addressline1 = SortOrder == "addressline1" ? "addressline1_desc" : "addressline1";
            ViewBag.certtype = SortOrder == "certtype" ? "certtype_desc" : "certtype";
            ViewBag.postcode = SortOrder == "postcode" ? "postcode_desc" : "postcode";
            ViewBag.operativename = SortOrder == "operativename" ? "operativename_desc" : "operativename";
            ViewBag.tradegroup = SortOrder == "tradegroup" ? "tradegroup_desc" : "tradegroup";
            ViewBag.eDocsRef = SortOrder == "eDocsRef" ? "eDocsRef_desc" : "eDocsRef";
            ViewBag.status = SortOrder == "status" ? "status_desc" : "status";
            ViewBag.datetime = SortOrder == "datetime" ? "datetime_desc" : "datetime";
            ViewBag.cause = SortOrder == "cause" ? "cause_desc" : "cause";

            var emp = from s in db.FirstTouchCertificates
                      select s;


            if (!string.IsNullOrEmpty(SortOrder))
            {
                switch (SortOrder)
                {
                    case "propertyid_desc":

                        model.lCertificates = model.lCertificates.AsEnumerable().OrderByDescending(s => s.propertyid).ToList();

                        break;
                    case "uprn_desc":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderByDescending(s => s.uprn).ToList();
                        break;
                    case "uprn":
                        emp = emp.OrderBy(s => s.uprn);
                        break;
                    case "addressline1_desc":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderByDescending(s => s.addressline1).ToList();
                        break;
                    case "addressline1":
                        emp = emp.OrderBy(s => s.addressline1);
                        break;
                    case "certtype_desc":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderByDescending(s => s.certtype).ToList();
                        break;
                    case "certtype":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderBy(s => s.certtype).ToList();
                        break;
                    case "postcode":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderBy(s => s.postcode).ToList();
                        break;
                    case "operativename":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderBy(s => s.operativename).ToList();
                        break;
                    case "tradegroup":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderBy(s => s.tradegroup).ToList();
                        break;
                    case "eDocsRef":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderBy(s => s.eDocsRef).ToList();
                        break;
                    case "status":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderBy(s => s.status).ToList();
                        break;
                    case "datetime":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderBy(s => s.datetime).ToList();
                        break;
                    case "cause":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderBy(s => s.cause).ToList();
                        break;
                    case "postcode_desc":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderByDescending(s => s.postcode).ToList(); ;
                        break;
                    case "operativename_desc":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderByDescending(s => s.operativename).ToList();
                        break;
                    case "tradegroup_desc":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderByDescending(s => s.tradegroup).ToList();
                        break;
                    case "eDocsRef_desc":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderByDescending(s => s.eDocsRef).ToList();
                        break;
                    case "status_desc":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderByDescending(s => s.status).ToList();
                        break;
                    case "datetime_desc":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderByDescending(s => s.datetime).ToList();
                        break;
                    case "cause_desc":
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderByDescending(s => s.cause).ToList();
                        break;
                    default:
                        model.lCertificates = model.lCertificates.AsEnumerable().OrderBy(s => s.propertyid).ToList();
                        break;
                }
            }
            return View(model);
        }



        // GET: Certificates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstTouchCertificate firstTouchCertificate = db.FirstTouchCertificates.Find(id);
            if (firstTouchCertificate == null)
            {
                return HttpNotFound();
            }
            return View(firstTouchCertificate);
        }

        // GET: Certificates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Certificates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,propertyid,uprn,addressline1,certtype,postcode,operativename,tradegroup,eDocsRef,status,datetime,cause")] FirstTouchCertificate firstTouchCertificate)
        {
            if (ModelState.IsValid)
            {
                db.FirstTouchCertificates.Add(firstTouchCertificate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(firstTouchCertificate);
        }

        // GET: Certificates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstTouchCertificate firstTouchCertificate = db.FirstTouchCertificates.Find(id);
            if (firstTouchCertificate == null)
            {
                return HttpNotFound();
            }
            return View(firstTouchCertificate);
        }

       

        // POST: Certificates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,propertyid,uprn,addressline1,certtype,postcode,operativename,tradegroup,eDocsRef,status,datetime,cause")] FirstTouchCertificate firstTouchCertificate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firstTouchCertificate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(firstTouchCertificate);
        }

        // GET: Certificates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstTouchCertificate firstTouchCertificate = db.FirstTouchCertificates.Find(id);
            if (firstTouchCertificate == null)
            {
                return HttpNotFound();
            }
            return View(firstTouchCertificate);
        }

        // POST: Certificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FirstTouchCertificate firstTouchCertificate = db.FirstTouchCertificates.Find(id);
            db.FirstTouchCertificates.Remove(firstTouchCertificate);
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
