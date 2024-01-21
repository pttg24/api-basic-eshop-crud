namespace BasicEshopCrud.Domain.Exceptions;

public class InvalidOrderException : Exception
{
    public InvalidOrderException(string message) : base(message)
    {
    }

    public InvalidOrderException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
