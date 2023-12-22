namespace Laudex.Models.Exceptions;

public class  FailedToAddException : Exception
{
    public FailedToAddException(string message):base(message)
    {
        
    }
}

public class FailedToUpdateException : Exception
{
    public FailedToUpdateException(string message) : base(message)
    {

    }
}

public class FailedToGetAllException : Exception
{
    public FailedToGetAllException(string message) : base(message)
    {

    }
}

public class FailedToGetByIdException : Exception
{
    public FailedToGetByIdException(string message) : base(message)
    {

    }
}

public class FailedToRemoveException : Exception
{
    public FailedToRemoveException(string message) : base(message)
    {

    }
}