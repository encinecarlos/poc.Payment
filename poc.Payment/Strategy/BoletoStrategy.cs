﻿namespace poc.Payment.Strategy
{
    public class BoletoStrategy : IPaymentStrategy
    {
        public string SendTransaction(decimal amount, string destination)
        {
            Console.WriteLine($"valor: {amount}, destinatario: {destination}");
            return $"B-{Guid.NewGuid()}";
        }
    }
}
