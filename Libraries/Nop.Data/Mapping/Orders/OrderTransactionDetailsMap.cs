using Nop.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data.Mapping.Orders
{
    public partial class OrderTransactionDetailsMap : NopEntityTypeConfiguration<OrderTransactionDetails>
    {
        public OrderTransactionDetailsMap()
        {
            this.ToTable("OrderTransactionDetails");
            this.HasKey(o => o.Id);
            this.Property(o => o.TransactionAmount).HasPrecision(18, 4);
      
            this.Ignore(o => o.PaymentStatus);
         
            
            this.HasRequired(o => o.Order)
                .WithMany(o=> o.OrderTransactionDetailItems)
                .HasForeignKey(o => o.OrderId);

        }
    }
}
