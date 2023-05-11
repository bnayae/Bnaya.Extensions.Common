namespace System.Collections
{
    public static class CollectionExtensions
    {
        #region ToEnumerable

        /// <summary>
        /// Converts to yield (IEnumerable) with single item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerable<T>(this T item)
        {
            yield return item;
        }

        /// <summary>
        /// Append elements to enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="item1">The item1.</param>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerable<T>(this IEnumerable<T> source, T item1, params T[] items)
        {
            foreach (var element in source)
            {
                yield return element;
            }
            yield return item1;
            foreach (var element in items)
            {
                yield return element;
            }
        }


        /// <summary>
        /// Create enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerable<T>(this T item1, T item2, params T[] items)
        {
            yield return item1;
            yield return item2;
            foreach (var element in items)
            {
                yield return element;
            }
        }

        /// <summary>
        /// Create enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerable<T>(this T item, IEnumerable<T> items)
        {
            yield return item;
            foreach (var element in items)
            {
                yield return element;
            }
        }

        /// <summary>
        /// Create enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerable<T>(this T item1, T item2, IEnumerable<T> items)
        {
            yield return item1;
            yield return item2;
            foreach (var element in items)
            {
                yield return element;
            }
        }

        /// <summary>
        /// Create enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <param name="item3">The item3.</param>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerable<T>(this T item1, T item2, T item3, IEnumerable<T> items)
        {
            yield return item1;
            yield return item2;
            yield return item3;
            foreach (var element in items)
            {
                yield return element;
            }
        }

        /// <summary>
        /// Create enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <param name="item3">The item3.</param>
        /// <param name="item4">The item4.</param>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerable<T>(this T item1, T item2, T item3, T item4, IEnumerable<T> items)
        {
            yield return item1;
            yield return item2;
            yield return item3;
            yield return item4;
            foreach (var element in items)
            {
                yield return element;
            }
        }

        #endregion // ToEnumerable
    }
}
