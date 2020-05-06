namespace GameResultApi.Infrastructure.Enum
{
    public enum ErrorType
    {
        NotError = 0,
        BusinessError = 1,
        ProgrammerError = 2,
        ExternalError = 3,
        TimeoutError = 4,
        ValidationError = 5,
        DeserializationError = 6
    }
}