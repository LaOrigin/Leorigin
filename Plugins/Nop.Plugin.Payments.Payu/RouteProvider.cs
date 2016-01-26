﻿using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;

namespace Nop.Plugin.Payments.Payu
{
    public partial class RouteProvider : IRouteProvider
    {
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

            routes.MapRoute("Plugin.Payments.Payu.ReturnDistributedOrder",
                "PaymentPayu/ReturnDistributedOrder",
                new { controller = "PaymentPayu", action = "ReturnDistributedOrder" },
                new[] { "Nop.Plugin.Payments.Payu.Controllers" });
           

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
