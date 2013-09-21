using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntLib6Lab.Web.Extensions
{
    public class CommonServiceLocatorControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? base.GetControllerInstance(requestContext, controllerType) : ServiceLocator.Current.GetInstance(controllerType) as IController;
        }
    }
}