using System.Collections.Generic;
using Nop.Web.Framework.Mvc;
using Nop.Web.Models.Common;

namespace Nop.Web.Models.Checkout
{
    public partial class CheckoutConfirmAddressModel : BaseNopModel
    {
        public CheckoutConfirmAddressModel()
        {
        
        }

        

        public AddressModel BillingAddress { get; set; }

        public AddressModel ShippingAddress { get; set; }

        public bool IsShippingEnable { get; set; }

        
    }
}