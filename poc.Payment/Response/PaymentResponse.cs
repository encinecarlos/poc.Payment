namespace poc.Payment.Response
{
    public class PaymentResponse
    {
        public string? TransactionId { get; set; }
        public string? Destination { get; set; }
        public decimal Amount { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
