using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Orders
{
   public partial  class OrderTransactionDetails: BaseEntity
    {

        #region Properties

        public int Id { get; set; }
        public int OrderId { get; set; }
        public string TransactionId { get; set; }
        public decimal TransactionAmount { get; set; }
        public int PaymentStatusId { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime TransactionDate { get; set; }

        # endregion

        #region Navigation Properties
        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        public virtual Order Order { get; set; }

        #endregion



        #region custom properties
        /// <summary>
        /// Gets or sets the payment status
        /// </summary>
        public Nop.Core.Domain.Payments.PaymentStatus PaymentStatus
        {
            get
            {
                return (Nop.Core.Domain.Payments.PaymentStatus)this.PaymentStatusId;
            }
            set
            {
                this.PaymentStatusId = (int)value;
            }
        }

        #endregion
    }
}
