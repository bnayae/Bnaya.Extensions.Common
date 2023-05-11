namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Factory for fetching the Key value registration by key
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class TypeFactory<T> where T : class
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public TypeFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Gets the type by a key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public T this[string key] => _serviceProvider.GetServices<KeyedData<T>>()
                                                    .Where(m => m.Key == key)
                                                    .Select(m => m.Item)
                                                    .FirstOrDefault();
    }
}
