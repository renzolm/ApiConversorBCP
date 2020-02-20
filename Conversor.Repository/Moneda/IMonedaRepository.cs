using Conversor.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Conversor.Repository.Moneda
{
  public  interface IMonedaRepository
    {
        Task<List<EMoneda>> ListarAsync();
        Task<decimal> CalcularAsync(string origen, string destino, decimal value);
    }
}
