namespace Microsoft.Extensions.DependencyInjection
{
    internal static class KeyedData
    {
        /// <summary>
        /// Creates.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public static KeyedData<T1> Create<T1>(string key, T1 item)
                    where T1 : class
                    => new KeyedData<T1>(key, item);
    }

    /// <summary>
    /// Key value class for registering key component
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class KeyedData<T> where T : class
    {

        /// <summary>
        /// Initializes a new instance .
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        public KeyedData(string key, T item)
        {
            Key = key;
            Item = item;
        }

        public string Key { get; }
        public T Item { get; }
    }
}
