using FirstTouchDashBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstTouchDashBoard.Controllers
{
    public class LoginCheck
    {

        private EDOCSIntegrationHubEntities db = new EDOCSIntegrationHubEntities();
        private string windowsUsername;
        private bool accessGranted = false;
        

        public bool checkUserAccess()
        {
            windowsUsername = Environment.UserName;
            var mod = new FirstTouchCertificateUsers();
            mod.lUsers = db.FirstTouchCertificateUser.ToList();

            foreach (var user in mod.lUsers)
            {
                if (user.userId.ToLower() == windowsUsername.ToLower())
                {
                    accessGranted = true;
               }
            }
            return accessGranted;
        }
    }
}