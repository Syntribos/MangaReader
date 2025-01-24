using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities;

public static class JsonValidation
{
    public static bool VerifyObject(object value, bool nullable)
    {
        if (value == null)
        {
            return nullable;
        }

        return true;
    }

    public static bool VerifyString(object value, bool nullable, int min, int max)
    {
        if (value is not string str)
        {
            return nullable;
        }

        return VerifyObject(value, nullable) && str.Length >= min && str.Length <= max;
    }

    public static Func<object, bool> VerifyString(bool nullable, int min, int max)
    {
        return (x => VerifyString(x, nullable, min, max));
    }
}
