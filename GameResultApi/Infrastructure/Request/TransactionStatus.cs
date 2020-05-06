using GameResultApi.Infrastructure.Enum;

namespace GameResultApi.Infrastructure.Request
{
    public class TransactionStatus
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public ErrorType ErrorType { get; set; }

        public EndTransactionType EndTransactionType { get; set; }

    }
}