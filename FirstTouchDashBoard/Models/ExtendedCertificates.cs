using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FirstTouchDashBoard.Models
{
    public class ExtendedCertificates
    {
        public List<FirstTouchCertificate> lCertificates { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public string certType { get; set; }
        public string uprn;
        public string propertyid;
        public string postCode;
    }
}