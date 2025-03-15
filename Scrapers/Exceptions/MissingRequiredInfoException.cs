using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Scrapers.Exceptions;

public class MissingRequiredInfoException : ArgumentNullException
{
    public MissingRequiredInfoException(string? paramName)
        : base(paramName)
    {
    }

    public static void ThrowIfNullOrEmpty<TKey, TValue>(
        [NotNull] Dictionary<TKey, TValue>? argument,
        [CallerArgumentExpression(nameof(argument))] string? paramName = null) 
        where TKey : notnull
    {
        ThrowIfNull(argument, paramName);

        if (argument.Count == 0)
        {
            Throw(paramName);
        }
    }

    public static void ThrowIfKeyMissing<TKey, TValue>(
        [NotNull] Dictionary<TKey, TValue>? argument,
        TKey key,
        [CallerArgumentExpression(nameof(argument))] string? paramName = null)
        where TKey : notnull
    {
        if (argument is null)
        {
            Throw(paramName);
        }

        if (!argument.ContainsKey(key))
        {
            Throw(paramName);
        }
    }

    new public static void ThrowIfNullOrEmpty(
        [NotNull] string? argument,
        [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (string.IsNullOrEmpty(argument))
        {
            Throw(paramName);
        }
    }

    new public static void ThrowIfNull(
        [NotNull] object? argument,
        [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is null)
        {
            Throw(paramName);
        }
    }

    public static void ThrowIfNullOrEmpty<T>(
        [NotNull] IEnumerable<T>? argument,
        [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is null)
        {
            Throw(paramName);
        }

        if (!argument.Any())
        {
            Throw(paramName);
        }
    }

    [DoesNotReturn]
    public static void Throw(string? paramName) =>
        throw new MissingRequiredInfoException(paramName);
}
