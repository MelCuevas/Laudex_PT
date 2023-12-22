namespace Laudex.Models.Exceptions;

public class MissingRequiredFieldException : Exception
{
    public MissingRequiredFieldException(string message) : base(message)
    {

    }
}