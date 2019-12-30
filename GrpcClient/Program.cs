using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001/");
            var input = new TransactionModel
            {
                UserId = 7,
                CustomerName = "Zone Switch",
                TransactionType = "Debit",
                TransactionAmount = 1098519,
                IssuingBank = "GtBank",
                TerminatingBank = "Fidelity"
            };
            var transactionClient = new Transaction.TransactionClient(channel);
            var reply = await transactionClient.SaveTransactionAsync(input);
            Console.WriteLine($"Unique transaction identifier code is {reply.TransactionId}, you can present this code at any of our partnering banks to get details about this transaction.");
            Console.ReadLine();
        }
    }
}
