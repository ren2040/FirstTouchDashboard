using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstTouchDashBoard.Models;

using System.Data;
using System.Data.Entity;


using System.Web.Mvc;

namespace FirstTouchDashBoard.Controllers.PageManagement
{
    public class Filtering 
    {
        public List<FirstTouchCertificate> filterResults(ExtendedCertificates mod, String filterPropId, String filterUprn, String filterPostCode, String filterCertType)
        {
            if (filterCertType.ToLower().Equals("both"))
            {

            }
            else
            {

                mod.lCertificates = mod.lCertificates.Where(m => m.certtype != null).ToList();
                mod.lCertificates = mod.lCertificates.Where(m => m.certtype.Contains(filterCertType)).ToList();
            }
            if (string.IsNullOrEmpty(filterPropId))
            {

            }
            else
            {



                mod.lCertificates = mod.lCertificates.Where(m => m.propertyid != null).ToList();
                mod.lCertificates = mod.lCertificates.Where(m => m.propertyid.Contains(filterPropId)).ToList();
            }

            if (string.IsNullOrEmpty(filterUprn))
            {

            }
            else
            {
                mod.lCertificates = mod.lCertificates.Where(m => m.uprn != null).ToList();
                mod.lCertificates = mod.lCertificates.Where(m => m.uprn.Contains(filterUprn)).ToList();
            }

            if (string.IsNullOrEmpty(filterPostCode))
            {

            }
            else
            {
                mod.lCertificates = mod.lCertificates.Where(m => m.postcode != null).ToList();
                mod.lCertificates = mod.lCertificates.Where(m => m.postcode.Contains(filterPostCode)).ToList();
            }

            return mod.lCertificates;
        }
    }
}