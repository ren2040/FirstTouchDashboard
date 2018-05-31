using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FirstTouchDashBoard.Models;

namespace FirstTouchDashBoard.Controllers
{
    public interface IPaging
    {
        List<FirstTouchCertificate> pagingResults(TempDataDictionary TempData, ExtendedCertificates mod, string numberOfResults, int page);
    }
}
