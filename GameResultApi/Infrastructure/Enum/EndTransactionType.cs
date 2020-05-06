using System.Runtime.Serialization;

namespace GameResultApi.Infrastructure.Enum
{
    [DataContract]
    public enum EndTransactionType
    {
        Success = 0,
        Error = 1
    }
}