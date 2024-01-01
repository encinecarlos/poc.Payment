using poc.Payment.Response;

namespace poc.Payment.Services
{
    public interface IPaymentService
    {
        PaymentResponse SendPayment(string method, decimal amount, string destination);
    }
}
