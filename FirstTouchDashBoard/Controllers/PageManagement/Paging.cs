using System;
using System.Collections.Generic;
using System.Linq;
using FirstTouchDashBoard.Models;
using System.Web;
using System.Web.Mvc;

namespace FirstTouchDashBoard.Controllers.PageManagement
{
    public class Paging 
    {
        public List<FirstTouchCertificate> pagingResults(TempDataDictionary TempData, ExtendedCertificates mod, string numberOfResults, int page)
        {
            if (!string.IsNullOrEmpty(numberOfResults))
            {
                var count = mod.lCertificates.Count();
                switch (numberOfResults)
                {
                    case "top50":

                        mod.lCertificates = mod.lCertificates.Skip(page * 2).Take(2).ToList();

                        TempData["Maxpage"] = (count / 2) - (count % 2 == 0 ? 1 : 0);

                        TempData["page"] = page;
                        break;
                    case "allResults":
                        mod.lCertificates = mod.lCertificates.Skip(page * 9999).Take(9999).ToList();

                        TempData["Maxpage"] = (count / 99999) - (count % 9999 == 0 ? 1 : 0);
                        TempData["page"] = page;
                        break;

                }

            }
            return mod.lCertificates;
        }
    }
}