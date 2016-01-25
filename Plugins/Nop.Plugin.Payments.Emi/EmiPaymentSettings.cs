using Nop.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Payments.Emi
{
    public class EmiPaymentSettings : ISettings
    {
        public string MerchantId { get; set; }
        public string Key { get; set; }
        public string MerchantParam { get; set; }
        public string PayUri { get; set; }
        public decimal AdditionalFee { get; set; }
    }
}
