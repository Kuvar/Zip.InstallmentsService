using Zip.InstallmentsService.Models;

namespace Zip.InstallmentsService.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentPlan> CreatePaymentPlan(decimal purchaseAmount, int installments, int frequency);
        Task<PaymentPlan?> GetPaymentPlanById(string id);
        Task<List<PaymentPlan>> GetAll();
    }
}
