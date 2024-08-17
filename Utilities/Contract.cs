using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities;

public static class Contract
{
    public static void RequireNotNull(object obj, string objName)
    {
        if (obj is null)
        {
            throw new ArgumentNullException($"{objName} cannot be null.");
        }
    }

    public static void RequireNotNull(params (object Object, string Name)[] values)
    {
        var cantBeNull = new List<string>();

        foreach (var item in values)
        {
            if (item.Object is null)
            {
                cantBeNull.Add(item.Name);
            }
        }

        if (cantBeNull.Any())
        {
            throw new ArgumentException($"The following object were null and shouldn't be: {string.Join(", ", cantBeNull)}.");
        }
    }

    public static void RequireNotNullOrEmpty(string value, string name)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException($"{name} cannot be null.");
        }
    }

    public static void RequireNotNullOrWhiteSpace(string value, string name)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException($"{name} cannot be null.");
        }
    }
}