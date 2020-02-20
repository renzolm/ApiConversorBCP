using Conversor.Entity.Entity;
using Conversor.Repository.Moneda;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conversor.Service.Moneda
{
    public class MonedaService : IMonedaService
    {
        private readonly IMonedaRepository _monedaRepository;
        public MonedaService(IMonedaRepository monedaRepository) {
            _monedaRepository = monedaRepository;
        }


        public async Task<decimal> CalcularAsync(string origen, string destino, decimal value)
        {
            try {

                return await _monedaRepository.CalcularAsync(origen, destino,value);

            } catch (Exception ex) {

                throw ex;
            }
        }

        public async Task<List<EMoneda>> ListarAsync()
        {
            try
            {

                return await _monedaRepository.ListarAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
