using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace FirstTouchDashBoard.Models
{
    public class ExtendedCertificates
    {
        [Required]
        public List<FirstTouchCertificate> lCertificates { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public string certType { get; set; }
        public string uprn { get; set; }    
        public string propertyid { get; set; }
        public string postCode { get; set; }

        public ExtendedCertificates()
        {
            from = new DateTime(2000, 01, 01);
            to = DateTime.Today;
            certType = "both";
            uprn = "";
            postCode = "";
            propertyid = "";
        }
    }
}