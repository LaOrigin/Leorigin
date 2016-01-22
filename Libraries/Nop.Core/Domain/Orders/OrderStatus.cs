namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// Represents an order status enumeration
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Pending
        /// </summary>
        Pending = 10,
        /// <summary>
        /// Processing
        /// </summary>
        Processing = 20,
        /// <summary>
        /// Complete
        /// </summary>
        Complete = 30,
        /// <summary>
        /// Cancelled
        /// </summary>
        Cancelled = 40,

        /// <summary>
        /// Booked
        /// </summary>
        Booked = 50,
        /// <summary>
        /// Confirm
        /// </summary>
        Confirmed = 60,
        /// <summary>
        /// PaymentComplete
        /// </summary>
        /// 
        OrderPaymentComplete = 70,
        /// <summary>
        /// PaymentComplete
        /// </summary>

        Delivered = 60
    }
}

