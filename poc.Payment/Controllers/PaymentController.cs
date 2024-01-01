using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using poc.Payment.Request;
using poc.Payment.Services;

namespace poc.Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public IActionResult MakePayment(PaymentRequest request) 
        {
            return Ok(_paymentService.SendPayment(request.Method, request.Amount, request.Destination));
        }
    }
}
