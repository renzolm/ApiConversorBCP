using Conversor.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conversor.Entity.Entity;

namespace Conversor.Api
{
    public static class EnsureMigration
    {
        public static void Run(this IApplicationBuilder builder, IConfiguration configuration) {

            using (var scope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var dbContext = scope.ServiceProvider.GetService<AppDbContext>())
                {

                    if (dbContext.Database.EnsureCreated())
                    {

                        if (dbContext.moneda.Count() == 0)
                        {

                            var moneda = new List<EMoneda> {

                                new EMoneda { Id =1, PaisOrigen = "Dolar Estadounidense" ,  PaisDestino = "Sol Peruano", TipoCambio="3.38080" },
                                new EMoneda { Id =2, PaisOrigen = "Sol Peruano" ,  PaisDestino = "Dolar Estadounidense", TipoCambio="0.295788" },
                            };

                            dbContext.moneda.AddRange(moneda);
                            dbContext.SaveChanges();
                        }
                    }


                }
            }
        
        }

    }
}
