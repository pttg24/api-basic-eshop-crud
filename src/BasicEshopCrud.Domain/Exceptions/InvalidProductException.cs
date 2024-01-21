namespace BasicEshopCrud.Domain.Exceptions;

public class InvalidProductException : Exception
{
    public InvalidProductException(string message) : base(message)
    {
    }

    public InvalidProductException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
