using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace FilterLists.Api.DependencyInjection.Extensions
{
    public static class ConfigureServicesCollection
    {
        public static void AddFilterListsApi(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddResponseCaching();
            services.AddMvcCustom();
            services.AddRoutingCustom();
            services.AddApiVersioning();
            TelemetryDebugWriter.IsTracingDisabled = true;
        }

        private static void AddMvcCustom(this IServiceCollection services) =>
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(opts =>
                    {
                        opts.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                        opts.SerializerSettings.ContractResolver = new SkipEmptyContractResolver();
                    });

        private static void AddRoutingCustom(this IServiceCollection services) =>
            services.AddRouting(opts => opts.LowercaseUrls = true);
    }
}