using poc.Payment.Enums;
using poc.Payment.Exceptions;
using poc.Payment.Response;
using poc.Payment.Strategy;

namespace poc.Payment.Services
{
    public class PaymentService : IPaymentService
    {
        private ILogger<PaymentService> _logger;

        public PaymentService(ILogger<PaymentService> logger)
        {
            _logger = logger;
        }

        private Dictionary<string, IPaymentStrategy> Strategies = new()
        {
            {PaymentMethod.Credit.ToString().ToLower(), new CreditCardStrategy()},
            {PaymentMethod.Debit.ToString().ToLower(), new DebitCardStrategy()},
            {PaymentMethod.Pix.ToString().ToLower(), new PixStrategy()},
            {PaymentMethod.Boleto.ToString().ToLower(), new BoletoStrategy()}
        };

        public PaymentResponse? SendPayment(string method, decimal amount, string destination)
        {            
            try
            {
                if(!Strategies.TryGetValue(method, out var payment))
                {
                    return new PaymentResponse
                    {
                        ErrorMessage = "Forma de pagamento não suportada."
                    };
                }

                var paymentId = payment?.SendTransaction(amount, destination);

                return new PaymentResponse
                {
                    Amount = amount,
                    Destination = destination,
                    TransactionId = paymentId
                };
            } catch (PaymentException ex) 
            {
                _logger.LogError(ex, $"Error: {ex.Message}\nTrace: {ex.StackTrace}");
                return new PaymentResponse
                {
                    ErrorMessage = "Erro ao processar o pagamento"
                };
            }
        }
    }
}
