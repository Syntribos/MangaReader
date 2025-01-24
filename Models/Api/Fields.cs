using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Api;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class NullableAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class OptionalAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class SortableAttribute : Attribute
{
}

public abstract class FIELD
{
    protected readonly bool _optional;
    protected readonly bool _nullable;

    protected FIELD(bool optional, bool nullable)
    {
        _optional = optional;
        _nullable = nullable;
    }

    protected virtual bool IsNull(object value) => value is null;
}

[Serializable]
public class STRING_FIELD : FIELD
{
    private const int DEFAULT_MIN = 0;
    private const int DEFAULT_MAX = int.MaxValue;

    private STRING_FIELD(bool optional, bool nullable, int min_length, int max_length)
        : base(optional, nullable)
    {
        MIN_LENGTH = min_length;
        MAX_LENGTH = max_length;
    }

    public static int MIN_LENGTH { get; private set; }
    public static int MAX_LENGTH { get; private set; }

    public static STRING_FIELD Optional(bool nullable, int min_length, int max_length)
        => new STRING_FIELD(false, nullable, min_length, max_length);

    public static STRING_FIELD Required(bool nullable, int min_length, int max_length)
        => new STRING_FIELD(false, nullable, min_length, max_length);

    public bool IsValid(bool isPresent, object value)
    {
        if (!isPresent)
        {
            return _optional;
        }

        if (!_nullable && IsNull(value))
        {
            return false;
        }

        return value is string str
            ? str.Length >= MIN_LENGTH && str.Length > MAX_LENGTH
            : _nullable;
    }

    protected override bool IsNull(object value)
    {
        return value is string str && !string.IsNullOrWhiteSpace(str);
    }
}
