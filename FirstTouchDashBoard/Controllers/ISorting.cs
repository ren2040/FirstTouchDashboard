using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstTouchDashBoard.Models;

namespace FirstTouchDashBoard.Controllers
{
    public interface ISorting
    {
        List<FirstTouchCertificate> sortResults(ExtendedCertificates mod, string SortOrder);
    }
}
