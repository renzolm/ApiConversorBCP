
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Conversor.Entity.Entity;
namespace Conversor.RestClient.Moneda
{
   public interface IMonedaRestClient
    {

        Task<List<EMoneda>> ListarAsync();
        Task<decimal> CalcularAsync(string origen, string destino, decimal value);
    }
}
