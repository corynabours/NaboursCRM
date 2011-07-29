using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using NaboursCRM.Service;

namespace NaboursCRM
{
    public class Global : HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute("Contacts", new WebServiceHostFactory(), typeof(PersonService)));

        }

        void Application_End(object sender, EventArgs e)
        {
        }

        void Application_Error(object sender, EventArgs e)
        {
        }

        void Session_Start(object sender, EventArgs e)
        {
        }

        void Session_End(object sender, EventArgs e)
        {
        }
    }
}
