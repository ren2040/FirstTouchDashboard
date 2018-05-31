using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using FirstTouchDashBoard.Models;
using FirstTouchDashBoard.Controllers.PageManagement;
using System.Net;
using System.Web;
namespace FirstTouchDashBoard.Controllers
{
    public class CertificatesController : Controller
    {
        public LoginCheck login = new LoginCheck();
        private EDOCSIntegrationHubEntities db = new EDOCSIntegrationHubEntities();
        private IFiltering filteringi;
        private ISorting sortingi;
        private IPaging pagingi;

        public CertificatesController(IPaging paging, ISorting sorting, IFiltering filtering)
        {
            filteringi = filtering;
            pagingi = paging;
            sortingi = sorting;
        }
        
        // GET: Certificates
        [HttpGet]
        public ActionResult Index(string SortOrder, string filterCertType, string filterPostCode,
            string filterPropId, string filterUprn, int page =0 , string  numberOfResults = "top50"  )
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
                ViewBag.numberOfResults = numberOfResults;
                ViewBag.Page = page;
               

               


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
              

                // Following single responsibility principle
                
                // Filtering certificates
                mod.lCertificates = filteringi.filterResults(mod, filterPropId, filterUprn, filterPostCode, filterCertType);
                //Sorting certificates
                mod.lCertificates = sortingi.sortResults(mod, SortOrder);
                //paging
                TempData["page"] = page;

                mod.lCertificates = pagingi.pagingResults(TempData, mod, numberOfResults, page );
               
                

                return View(mod);
            }
        }
       

        

        

        
        
        
    }
}
