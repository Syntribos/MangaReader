using System;

namespace Utilities;

public static class Contract
{
    public static void RequireNotNull(object obj, string objType)
    {
        if (obj is null)
        {
            throw new ArgumentNullException($"{objType} cannot be null.");
        }
    }

    public static void RequireNotNullOrEmpty(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException();
        }
    }
}