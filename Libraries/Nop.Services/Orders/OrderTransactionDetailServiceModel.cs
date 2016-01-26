using Nop.Core.Domain.Orders;
using Nop.Services.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Orders
{
    public partial class OrderTransactionDetailServiceModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public OrderStatus Status { get; set; }
        public bool IsEmiOption { get; set; }
        public string PaymentMethodSystemName { get; set; }
    }
}
