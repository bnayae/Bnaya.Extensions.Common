using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Weknow_BasicExtensions_Tests
{
    public class TestStartup : Startup
    {
        public TestStartup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                //.SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureTestServices(IServiceCollection services)
        {
            services.Replace(ServiceDescriptor.Scoped<IService, MockedService>());
            services.AddEntityFrameworkSqlite()
                .AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlite(connection)
                );
        }

        public void Configure(IApplicationBuilder app)
        {
            // your usual registrations there
        }
    }
}
