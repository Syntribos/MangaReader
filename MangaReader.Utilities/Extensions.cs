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

        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> list)
        {
            return list.OrderBy(x => x);
        }
        
        public static IDictionary<TDictKey, TDictValue> ToDistinctDictionary<TValue, TDictKey, TDictValue>(
            this IEnumerable<TValue> list,
            Func<TValue, TDictKey> keySelector,
            Func<TValue, TDictValue> valueSelector)
        {
            return list.ToDistinctDictionary(keySelector, keySelector, valueSelector);
        }

        public static IDictionary<TDictKey, TDictValue> ToDistinctDictionary<TValue, TEquality, TDictKey, TDictValue>(
            this IEnumerable<TValue> list,
            Func<TValue, TEquality> equalitySelector,
            Func<TValue, TDictKey> keySelector,
            Func<TValue, TDictValue> valueSelector)
        {
            return list.GroupBy(x => equalitySelector).Select(x => x.First()).ToDictionary(keySelector, valueSelector);
        }
    }
}
