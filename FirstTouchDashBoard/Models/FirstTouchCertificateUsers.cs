using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstTouchDashBoard.Models
{
    public class FirstTouchCertificateUsers
    {
       
        public List<FirstTouchCertificateUser> lUsers { get; set; }
        

        public FirstTouchCertificateUsers()
        {
            
        }
    }
}