namespace poc.Payment.Request
{
    public class PaymentRequest
    {
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public decimal Amount { get; set; }
        public string? Method { get; set; }
    }
}
