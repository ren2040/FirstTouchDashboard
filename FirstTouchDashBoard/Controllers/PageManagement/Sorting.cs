using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstTouchDashBoard.Models;

namespace FirstTouchDashBoard.Controllers.PageManagement
{
    public class Sorting
    {
        public List<FirstTouchCertificate> sortResults(ExtendedCertificates mod, string SortOrder)
        {
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

            return mod.lCertificates;
        }
    }
}