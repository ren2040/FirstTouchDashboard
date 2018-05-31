using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstTouchDashBoard.Models;

namespace FirstTouchDashBoard.Controllers
{
    public interface IFiltering
    {
        List<FirstTouchCertificate> filterResults(ExtendedCertificates mod, String filterPropId, String filterUprn, String filterPostCode, String filterCertType);
    }
}
