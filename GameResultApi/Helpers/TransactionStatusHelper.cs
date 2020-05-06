using GameResultApi.Infrastructure.Enum;
using GameResultApi.Infrastructure.Request;

namespace GameResultApi.Helpers
{
    public class TransactionStatusHelper
    {
        ///<summary>
        /// Function to generate a new transaction status
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <param name="error"></param>

        public static TransactionStatus CreateTransaction(string code = "200", string message = "Success Operation", EndTransactionType type = EndTransactionType.Success, ErrorType error = ErrorType.NotError)
        {
            TransactionStatus status = new TransactionStatus()
            {
                Code = code,
                Message = message,
                EndTransactionType = type,
                ErrorType = error,
            };
            return status;
        }
    }
}