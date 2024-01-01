namespace poc.Payment.Exceptions
{
    public class PaymentException : Exception
    {
        public PaymentException(string message) : base(message) { }
    }
}
