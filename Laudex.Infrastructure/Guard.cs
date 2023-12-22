// ---------------------------------------------------------------------------------- 
// Copyright (c) Laudex
// Licensed under the MIT License
// ----------------------------------------------------------------------------------

namespace Laudex.Infrastructure;

public class Guard
{
    public static void AgainstNullOrDefault<T>(T value, string name)
    {
        if (value.Equals(default(T)))
            throw new MissingRequiredFieldException($"El campo {name} es mandatorio");
    }

    public static void AgainstNull(object value, string name)
    {
        if (value == null)
            throw new MissingRequiredFieldException($"El campo {name} es mandatorio");
    }

    public static void AgainstEmptyOrNull(object value, string name)
    {
        if (value == null)
            throw new MissingRequiredFieldException($"El campo {name} es mandatorio");
    }
}