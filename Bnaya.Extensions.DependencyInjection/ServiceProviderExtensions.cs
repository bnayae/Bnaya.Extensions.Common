namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Service provider extensions
    /// </summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Gets the type by a key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public static T GetService<T>(
            this IServiceProvider serviceProvider,
            Func<T, bool> filter)
                    where T : class
        {
            T result = serviceProvider.GetServices<T>()
                                            .FirstOrDefault(filter);
            return result;
        }

    }
}
