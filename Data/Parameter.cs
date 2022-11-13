using System.Collections.Generic;

namespace Data;

public class Parameter
{
    private Parameter(string name, string value)
    {
        Name = name;
        Value = value;
    }
    
    public string Name { get; }
    
    public string Value { get; }

    public static Parameter CreateParameter(string name, string value)
    {
        return new Parameter(name, value);
    }

    public static Parameter CreateParameter(string name, IEnumerable<string> values)
    {
        var value = string.Join(", ", values);
        return new Parameter(name, value);
    }
}