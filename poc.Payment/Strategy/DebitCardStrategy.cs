namespace poc.Payment.Strategy
{
    public class DebitCardStrategy : IPaymentStrategy
    {
        public string SendTransaction(decimal amount, string destination)
        {
            Console.WriteLine($"valor: {amount}, destinatario: {destination}");
            return new Random().Next(1_000_000, int.MaxValue).ToString();
        }
    }
}
