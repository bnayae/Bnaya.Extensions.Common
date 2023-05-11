namespace Microsoft.Extensions.DependencyInjection
{
    public static class DIExtensions
    {

        /// <summary>
        /// Adds a singleton service with a Key.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="services">The IServiceCollection to add the service to.</param>
        /// <param name="key">The key.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">services</exception>
        public static IServiceCollection AddSingletonWithKey<TService>(
                                this IServiceCollection services,
                                string key,
                                Func<IServiceProvider, TService> implementationFactory) where TService : class
        {
            services = services.AddSingleton<KeyedData<TService>>(sp =>
            {
                TService service = implementationFactory(sp);
                var keyed = KeyedData.Create(key, service);
                return keyed;
            });
            services = services.AddSingleton<TypeFactory<TService>>();
            return services;
        }
    }
}
