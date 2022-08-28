using System;
using System.Collections.Generic;
using System.Linq;

namespace MangaReader.Utilities
{
    public static class Extensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue defaultValue)
        {
            return dictionary.TryGetValue(key, out var value) ? value : defaultValue;
        }

        public static TValue GetValueOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TValue> defaultValueProvider)
        {
            return dictionary.TryGetValue(key, out var value)
                ? value
                : defaultValueProvider();
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }

        public static IEnumerable<T> Sort<T>(this IEnumerable<T> list)
        {
            return list.OrderBy(x => x);
        }
    }
}
