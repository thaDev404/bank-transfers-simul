namespace GrpcServer.Data.Entities
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public long TransactionId { get; set; }
        public string CustomerName { get; set; }
        public string TransactionType { get; set; }
        public int TransactionAmount { get; set; }
        public string TerminatingBank { get; set; }
        public string IssuingBank { get; set; }
    }
}
