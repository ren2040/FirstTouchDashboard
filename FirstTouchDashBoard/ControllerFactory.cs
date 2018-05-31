using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstTouchDashBoard.Controllers;

namespace FirstTouchDashBoard
{
    public class ControllerFactory : DefaultControllerFactory
    {
        private IPaging _paging;
        private ISorting _sorting;
        private IFiltering _filtering;
        public ControllerFactory(IPaging paging, ISorting sorting, IFiltering filtering)
        {
            _paging = paging;
            _sorting = sorting;
            _filtering = filtering;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            IController controller = null;
            if (controllerType == typeof(CertificatesController))
            {
                controller = new CertificatesController(_paging, _sorting, _filtering);
            }
            else if(controllerType == typeof(AdministrationController))
            {
                controller = new AdministrationController();
            }
            else
            {
                controller = null;
            }
            return controller;
        }
    }
}