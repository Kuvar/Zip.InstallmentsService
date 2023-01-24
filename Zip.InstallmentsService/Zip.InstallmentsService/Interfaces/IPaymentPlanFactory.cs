using Microsoft.AspNetCore.Mvc;
using Zip.InstallmentsService.Models;

namespace Zip.InstallmentsService.Interfaces
{
    public interface IPaymentPlanFactory
    {
        Task<ActionResult<PaymentPlan>> CreatePaymentPlan(decimal purchaseAmount, int installments, int frequency);
        Task<ActionResult<List<PaymentPlan>>> GetAllPaymentPlans();
        Task<ActionResult<PaymentPlan>> GetPaymentPlanById(string id);
    }
}
