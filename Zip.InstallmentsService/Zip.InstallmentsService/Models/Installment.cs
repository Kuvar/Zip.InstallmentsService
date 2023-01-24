using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zip.InstallmentsService.Models
{
    /// <summary>
    /// Data structure which defines all the properties for an installment.
    /// </summary>
    public class Installment
    {
        /// <summary>
        /// Gets or sets the unique identifier for each installment.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the date that the installment payment is due.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the amount of the installment.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the fk_PaymentPlanId of the installment.
        /// </summary>
        
        public Guid PaymentPlanId { get; set; }

        [ForeignKey("PaymentPlanId")]
        public virtual PaymentPlan PaymentPlan { get; set; }
    }
}
