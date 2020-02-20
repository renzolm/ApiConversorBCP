using Conversor.RestClient.Moneda;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conversor.Client.Configuration
{
    public class IoCContainerConfiguration
    {
        public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IMonedaRestClient, MonedaRestClient>();

        }
     }
}
