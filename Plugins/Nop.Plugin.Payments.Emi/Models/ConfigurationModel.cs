using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Payments.Emi.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.Payments.Emi.MerchantId")]
        public string MerchantId { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Emi.Key")]
        public string Key { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Emi.MerchantParam")]
        public string MerchantParam { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Emi.PayUri")]
        public string PayUri { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Emi.AdditionalFee")]
        public decimal AdditionalFee { get; set; }
    }
}
