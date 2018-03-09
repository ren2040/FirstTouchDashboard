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
        public ActionResult Index(string SortOrder, string filterCertType, string filterPostCode,
            string filterPropId, string filterUprn, int page = 0)
        {
            // Update viewbag with filter details
            if (string.IsNullOrEmpty(filterCertType))
            {
                filterCertType = "both";
                ViewBag.filterCertType = "both";
            }
            else
            {

                ViewBag.filterCertType = filterCertType;
            }

          
                ViewBag.filterPostCode = filterPostCode;
                ViewBag.filterPropId = filterPropId;
                ViewBag.filterUprn = filterUprn;
            


            var mod = new ExtendedCertificates();

            mod.lCertificates = db.FirstTouchCertificates.ToList();

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

            if (ViewBag.filterCertType.ToLower().Equals("both"))
            {

            }
            else
            {
                mod.lCertificates = mod.lCertificates.Where(m => m.certtype != null).ToList();
                mod.lCertificates = mod.lCertificates.Where(m => m.certtype.Contains(ViewBag.filterCertType)).ToList();
            }
            if (string.IsNullOrEmpty(filterPropId))
            {

            }
            else
            {



                mod.lCertificates = mod.lCertificates.Where(m => m.propertyid != null).ToList();
                mod.lCertificates = mod.lCertificates.Where(m => m.propertyid.Contains(ViewBag.filterPropId)).ToList();
            }

            if (string.IsNullOrEmpty(filterUprn))
            {

            }
            else
            {
                mod.lCertificates = mod.lCertificates.Where(m => m.uprn != null).ToList();
                mod.lCertificates = mod.lCertificates.Where(m => m.uprn.Contains(ViewBag.filterUprn)).ToList();
            }

            if (string.IsNullOrEmpty(filterPostCode))
            {

            }
            else
            {
                mod.lCertificates = mod.lCertificates.Where(m => m.postcode != null).ToList();
                mod.lCertificates = mod.lCertificates.Where(m => m.postcode.Contains(ViewBag.filterPostCode)).ToList();
            }
            

         

           
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
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderBy(s => s.uprn).ToList();
                        break;
                    case "addressline1_desc":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderByDescending(s => s.addressline1).ToList();
                        break;
                    case "addressline1":
                        mod.lCertificates = mod.lCertificates.AsEnumerable().OrderBy(s => s.addressline1).ToList();
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
            const int PageSize = 2;
            var count = mod.lCertificates.Count();
            mod.lCertificates = mod.lCertificates.Skip(page * PageSize).Take(PageSize).ToList();

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1  : 0);
            this.ViewBag.Page = page;
            







            return View(mod);
        }



        
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
