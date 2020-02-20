using Conversor.Entity.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conversor.Context.Configuration
{
    public class MonedaConfiguration
    {
       
        public MonedaConfiguration(EntityTypeBuilder<EMoneda> entityTypeBuilder)
        {
            //entityTypeBuilder.HasData(new EMoneda { Id = 1, Pais = "Perú", TipoCambio = "3.25" });

        }
    }
}
