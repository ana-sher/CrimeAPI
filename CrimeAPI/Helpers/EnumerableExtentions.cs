namespace CrimeAPI.Helpers
{
    /// <summary>
    /// Extensions methods for IEnumerable.
    /// </summary>
    public static class EnumerableExtentions
    {
        /// <summary>
        /// Creates a System.Collections.Generic.Dictionary from an System.Collections.Generic.IEnumerable
        /// according to a specified key selector function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="source">An System.Collections.Generic.IEnumerable to create a System.Collections.Generic.Dictionary from.</param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <returns>A System.Collections.Generic.Dictionary that contains keys and values in System.Collections.Generic.List.</returns>
        public static Dictionary<TKey, List<TSource>> ToDictionaryWithDuplicateKeys<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) where TKey : notnull
        {
            var dict = new Dictionary<TKey, List<TSource>>();
            foreach (var item in source)
            {
                var key = keySelector(item);
                if (dict.ContainsKey(key))
                {
                    dict[key].Add(item);
                }
                else
                {
                    dict.Add(key, [item]);
                }
            }
            return dict;
        }
    }
}
