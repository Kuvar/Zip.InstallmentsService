using static System.Net.WebRequestMethods;

namespace Zip.InstallmentsService.Models
{
    public class PaymentResponse
    {
        public PaymentPlan payment_plan { get; set; }
        public int status_codes { get; set; }
        public string status_message { get; set;}
    }
}
