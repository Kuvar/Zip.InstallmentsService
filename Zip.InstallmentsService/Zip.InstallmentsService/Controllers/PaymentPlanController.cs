using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Zip.InstallmentsService.db;
using Zip.InstallmentsService.Interfaces;
using Zip.InstallmentsService.Models;
using Zip.InstallmentsService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zip.InstallmentsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentPlanController : ControllerBase
    {
        private readonly InstallmentContext _context;
        private readonly IPaymentService _paymentService;
        public PaymentPlanController(InstallmentContext context, IPaymentService paymentService)
        {
            _context = context;
            _paymentService= paymentService;

        }

        [HttpGet("~/GetAllPaymentPlans")]
        public async Task<ActionResult<List<PaymentPlan>>> GetAllPaymentPlans()
        {
            try
            {
                if (_context.PaymentPlans == null)
                {
                    return NotFound();
                }
                return Ok(await _paymentService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/<PaymentPlanController>
        [HttpGet("~/CreatePaymentPlan")]
        public async Task<ActionResult<PaymentPlan>> CreatePaymentPlan(decimal purchaseAmount, int installments, int frequency)
        {
            try
            {
                if (purchaseAmount <= 0)
                    return BadRequest("Purchase amount is not valid.");
                if (purchaseAmount <= 0 || installments <= 0)
                    return BadRequest("Installments must be greater than 0.");
                if (frequency <= 0 || installments <= 0)
                    return BadRequest("Frequency must be greater than 0.");
                if (_context.PaymentPlans == null)
                    return NotFound();

                return Ok(await _paymentService.CreatePaymentPlan(purchaseAmount, installments, frequency));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/PaymentPlan/GetPaymentPlanById/5
        [HttpGet("~/GetPaymentPlanById/{id}")]
        public async Task<ActionResult<PaymentPlan>> GetPaymentPlanById(string id)
        {
            try
            {
                var result = Ok(await _paymentService.GetPaymentPlanById(id));
                if (result is null)
                    return NotFound("Service not found.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
