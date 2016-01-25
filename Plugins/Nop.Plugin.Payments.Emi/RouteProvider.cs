
using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;

namespace Nop.Plugin.Payments.Emi
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {

            routes.MapRoute("Plugin.Payments.Emi.Configure",
                 "Plugins/PaymentEmi/Configure",
                 new { controller = "PaymentEmi", action = "Configure" },
                 new[] { "Nop.Plugin.Payments.Emi.Controllers" }
            );

            routes.MapRoute("Plugin.Payments.Emi.PaymentInfo",
                 "Plugins/PaymentEmi/PaymentInfo",
                 new { controller = "PaymentEmi", action = "PaymentInfo" },
                 new[] { "Nop.Plugin.Payments.Emi.Controllers" }
            );

            routes.MapRoute("Plugin.Payments.Emi.Return",
                "PaymentEmi/Return",
                new { controller = "PaymentEmi", action = "Return" },
                new[] { "Nop.Plugin.Payments.Emi.Controllers" });



        }
        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}
