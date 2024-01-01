namespace poc.Payment.Strategy
{
    public interface IPaymentStrategy
    {
        string SendTransaction(decimal amount, string destination);
    }
}
