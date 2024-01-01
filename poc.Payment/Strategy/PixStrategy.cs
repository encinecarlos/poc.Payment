namespace poc.Payment.Strategy
{
    public class PixStrategy : IPaymentStrategy
    {
        public string SendTransaction(decimal amount, string destination)
        {
            Console.WriteLine($"valor: {amount}, destinatario: {destination}");
            return Guid.NewGuid().ToString();
        }
    }
}
