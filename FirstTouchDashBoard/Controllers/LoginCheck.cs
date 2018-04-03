using FirstTouchDashBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstTouchDashBoard.Controllers
{
    public class LoginCheck
    {

        public EDOCSIntegrationHubEntities db = new EDOCSIntegrationHubEntities();
        public string windowsUsername;
        public bool accessGranted = false;
        

        public bool checkUserAccess()
        {
            windowsUsername = Environment.UserName;
            var mod = new FirstTouchCertificateUsers();
            mod.lUsers = db.FirstTouchCertificateUser.ToList();

            foreach(var user in mod.lUsers)
            {
                if (user.userId == windowsUsername)
                {
                    accessGranted = true;
               }
            }
            return accessGranted;
        }
    }
}