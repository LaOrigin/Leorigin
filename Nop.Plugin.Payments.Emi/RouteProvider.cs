

using Nop.Web.Framework.Mvc.Routes;
using System.Web.Mvc;
using System.Web.Routing;


namespace Nop.Plugin.Payments.Emi
{
    public partial class RouteProvider : IRouteProvider
    {
        public int Priority
        {
            get
            {
                return 0;
            }
        }

        public void RegisterRoutes(RouteCollection routes)
        {
            
            routes.MapRoute("Plugin.Payments.Payu.Configure",
                  "Plugins/PaymentPayu/Configure",
                  new { controller = "PaymentPayu", action = "Configure" },
                  new[] { "Nop.Plugin.Payments.Payu.Controllers" }
             );

            routes.MapRoute("Plugin.Payments.Payu.PaymentInfo",
                 "Plugins/PaymentPayu/PaymentInfo",
                 new { controller = "PaymentPayu", action = "PaymentInfo" },
                 new[] { "Nop.Plugin.Payments.Payu.Controllers" }
            );

        }
    }
}
