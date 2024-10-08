using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivesBlog.SDK.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApi(this IServiceCollection services, string apiUri)
        {
            // Register HttpClientFactory (assumes it will be configured in your Program.cs or Startup.cs)
            services.AddHttpClient("VivesBlogApi", options =>
            {
                options.BaseAddress = new Uri(apiUri);
            });

            // Register the SDK services
            services.AddScoped<PersonSdk>();
            services.AddScoped<ArticleSdk>();

            return services;
        }
    }
}
