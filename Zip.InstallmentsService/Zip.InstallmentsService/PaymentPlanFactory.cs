using Microsoft.AspNetCore.Mvc;
using Zip.InstallmentsService.Controllers;
using Zip.InstallmentsService.db;
using Zip.InstallmentsService.Interfaces;
using Zip.InstallmentsService.Models;
using Zip.InstallmentsService.Services;

namespace Zip.InstallmentsService
{
    /// <summary>
    /// This class is responsible for building the PaymentPlan according to the Zip product definition.
    /// </summary>
    public class PaymentPlanFactory : IPaymentPlanFactory
    {
        private readonly PaymentPlanController _payment;

        public PaymentPlanFactory(InstallmentContext context, IPaymentService paymentService)
        {
            _payment = new PaymentPlanController(context, paymentService);
        }


        /// <summary>
        /// Builds the PaymentPlan instance.
        /// </summary>
        /// <param name="purchaseAmount"></param>
        /// <param name="installments"></param>
        /// <param name="frequency"></param>
        /// <returns>The PaymentPlan created with all properties set.</returns>
        public async Task<ActionResult<PaymentPlan>> CreatePaymentPlan(decimal purchaseAmount, int installments, int frequency)
        {
            return  await _payment.CreatePaymentPlan(purchaseAmount, installments, frequency); 
        }

        /// <summary>
        /// Return all PaymentPlan.
        /// </summary>
        /// <returns>The GetAllPaymentPlans return all paymentplans</returns>
        public async Task<ActionResult<List<PaymentPlan>>> GetAllPaymentPlans()
        {
            return await _payment.GetAllPaymentPlans();
        }


        // <summary>
        /// Return all PaymentPlan.
        /// </summary>
        /// <param name="id">PaymentPlanId</param>
        /// <returns>The GetPaymentPlanById return paymentplans of given id</returns>
        public async Task<ActionResult<PaymentPlan>> GetPaymentPlanById(string id)
        {
            return await _payment.GetPaymentPlanById(id);
        }
    }
}
