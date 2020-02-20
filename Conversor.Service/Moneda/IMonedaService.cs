using Conversor.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conversor.Service.Moneda
{
   public interface IMonedaService
    {
        Task<List<EMoneda>> ListarAsync();
        Task<decimal> CalcularAsync(string origen, string destino, decimal value);
    }
}
