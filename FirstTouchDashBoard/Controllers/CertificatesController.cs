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
            if(mod.propertyid != null)
            {
                mod.lCertificates = mod.lCertificates.Where(m => m.propertyid.Contains(m.propertyid)).ToList();
            }
            if(mod.uprn != null)
            {
                mod.lCertificates = mod.lCertificates.Where(m => m.uprn.Contains(m.uprn)).ToList();
            }
            if(mod.certType != null)
            {
                mod.lCertificates = mod.lCertificates.Where(m => m.certtype.Contains(m.certtype)).ToList();
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
                        emp = emp.OrderByDescending(s => s.uprn);
                        break;
                    case "uprn":
                        emp = emp.OrderBy(s => s.uprn);
                        break;
                    case "addressline1_desc":
                        emp = emp.OrderByDescending(s => s.addressline1);
                        break;
                    case "addressline1":
                        emp = emp.OrderBy(s => s.addressline1);
                        break;
                    case "certtype_desc":
                        emp = emp.OrderByDescending(s => s.certtype);
                        break;
                    case "certtype":
                        emp = emp.OrderBy(s => s.certtype);
                        break;
                    case "postcode":
                        emp = emp.OrderBy(s => s.postcode);
                        break;
                    case "operativename":
                        emp = emp.OrderBy(s => s.operativename);
                        break;
                    case "tradegroup":
                        emp = emp.OrderBy(s => s.tradegroup);
                        break;
                    case "eDocsRef":
                        emp = emp.OrderBy(s => s.eDocsRef);
                        break;
                    case "status":
                        emp = emp.OrderBy(s => s.status);
                        break;
                    case "datetime":
                        emp = emp.OrderBy(s => s.datetime);
                        break;
                    case "cause":
                        emp = emp.OrderBy(s => s.cause);
                        break;
                    case "postcode_desc":
                        emp = emp.OrderByDescending(s => s.postcode);
                        break;
                    case "operativename_desc":
                        emp = emp.OrderByDescending(s => s.operativename);
                        break;
                    case "tradegroup_desc":
                        emp = emp.OrderByDescending(s => s.tradegroup);
                        break;
                    case "eDocsRef_desc":
                        emp = emp.OrderByDescending(s => s.eDocsRef);
                        break;
                    case "status_desc":
                        emp = emp.OrderByDescending(s => s.status);
                        break;
                    case "datetime_desc":
                        emp = emp.OrderByDescending(s => s.datetime);
                        break;
                    case "cause_desc":
                        emp = emp.OrderByDescending(s => s.cause);
                        break;
                    default:
                        emp = emp.OrderBy(s => s.propertyid);
                        break;
                    


                }
                 
             

            }
            


          
                return View(emp.ToList());
          
            
              

            

           
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
