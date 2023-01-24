using Azure;
using Microsoft.EntityFrameworkCore;
using Zip.InstallmentsService.db;
using Zip.InstallmentsService.Interfaces;
using Zip.InstallmentsService.Models;

namespace Zip.InstallmentsService.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly InstallmentContext _context;
        public PaymentService(InstallmentContext context)
        {
            _context= context;
        }

        public async Task<List<PaymentPlan>> GetAll()
        {
            var result = await _context.PaymentPlans.ToListAsync();
            return result;

        }

        public async Task<PaymentPlan> CreatePaymentPlan(decimal purchaseAmount, int installments, int frequency)
        {
            var paymentPlan = new PaymentPlan();
            DateTime date = DateTime.Now;
            decimal emiAmmount = purchaseAmount / installments;
            paymentPlan.Id = Guid.NewGuid();
            paymentPlan.PurchaseAmount = purchaseAmount;
            while (purchaseAmount > 0)
            {
                var installment = new Installment();
                installment.Id = Guid.NewGuid();
                installment.DueDate = date;
                installment.Amount = emiAmmount;
                paymentPlan.Installments.Add(installment);

                purchaseAmount -= emiAmmount;
                date = date.AddDays(frequency);
            }
            await _context.PaymentPlans.AddAsync(paymentPlan);
            await _context.SaveChangesAsync();

            return paymentPlan;
        }

        public async Task<PaymentPlan?> GetPaymentPlanById(string id)
        {
            PaymentPlan plan = new PaymentPlan();
            plan = await _context.PaymentPlans.FirstOrDefaultAsync(c => c.Id.ToString() == id);
            plan.Installments = await _context.Installmentes.Where(c => c.PaymentPlanId.ToString() == id).ToListAsync();

            if (plan is null)
                return null;
                       
            return plan;
        }
    }
}
