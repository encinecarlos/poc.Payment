namespace poc.Payment.Strategy
{
    public class CreditCardStrategy : IPaymentStrategy
    {
        public string SendTransaction(decimal amount, string destination)
        {
            Console.WriteLine($"valor: {amount}, destinatario: {destination}");
            return $"CR-{Guid.NewGuid()}";
        }
    }
}
