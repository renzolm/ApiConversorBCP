using Conversor.Repository.Moneda;
using Conversor.Service.Moneda;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conversor.Api.Configuration
{
    public class IoCConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration) {

            services.AddTransient<IMonedaRepository, MonedaRepository>();
            services.AddTransient<IMonedaService, MonedaService>();
        }
    }
}
