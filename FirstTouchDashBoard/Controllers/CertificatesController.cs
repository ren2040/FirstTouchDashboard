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
        public LoginCheck login = new LoginCheck();
       

        private EDOCSIntegrationHubEntities db = new EDOCSIntegrationHubEntities();

        // GET: Certificates
        [HttpGet]
        public ActionResult Index(string SortOrder, string filterCertType, string filterPostCode,
            string filterPropId, string filterUprn, string numberOfResults , int page = 0)
        {
            
            if (login.checkUserAccess() != true)
            {
                return View("Unauthorised");
            }
            else
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
                numberOfResults = ViewBag.numberOfResults  == "allResults" ? "top50" : "allResults";
          

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
                if (!string.IsNullOrEmpty(numberOfResults))
                {
                   var count = mod.lCertificates.Count();
                    switch (numberOfResults)
                   {
                        case "top50":
                            
                            mod.lCertificates = mod.lCertificates.Skip(page * 2).Take(2).ToList();
                        
                            this.ViewBag.MaxPage = (count / 2) - (count % 2 == 0 ? 1 : 0);
                            this.ViewBag.Page = page;
                            break;
                        case "allResults":
                            mod.lCertificates = mod.lCertificates.Skip(page * 9999).Take(9999).ToList();
                          
                            this.ViewBag.MaxPage = (count / 99999) - (count % 9999 == 0 ? 1 : 0);
                            this.ViewBag.Page = page;
                            break;

                    }
                } 
                
                










                return View(mod);
            }
        }



        
        
        
    }
}
