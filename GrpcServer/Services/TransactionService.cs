using Grpc.Core;
using GrpcServer.Data;
using GrpcServer.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class TransactionService : Transaction.TransactionBase
    {
        private readonly ILogger<TransactionService> _logger;
        private readonly ZoneSwitchContext _context;

        public TransactionService(ILogger<TransactionService> logger, ZoneSwitchContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override Task<TransactionLookupModel> SaveTransaction(TransactionModel req, ServerCallContext context)
        {
            string transactionId = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            var transaction = new TransactionEntity {
                TransactionId = Int64.Parse(transactionId), UserId = req.UserId, CustomerName = req.CustomerName, 
                IssuingBank = req.IssuingBank, TerminatingBank =  req.TerminatingBank, 
                TransactionAmount = req.TransactionAmount, TransactionType = req.TransactionType 
            };
            _context.TransactionEntity.Add(transaction);
            _context.SaveChanges();

            return Task.FromResult(new TransactionLookupModel {
                TransactionId = transactionId
            });
        }
    }
}
