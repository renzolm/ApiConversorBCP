using Conversor.Context;
using Conversor.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Conversor.Repository.Moneda
{
    public class MonedaRepository : IMonedaRepository
    {
        private readonly AppDbContext _dbContext;

        public MonedaRepository(AppDbContext dbContext) {

            _dbContext = dbContext;
        }
        public async Task<decimal> CalcularAsync(string origen , string destino, decimal value)
        {
            try
            {
                var tipoCambio = await _dbContext.moneda.Where(m => m.PaisOrigen == origen.Trim() && m.PaisDestino == destino.Trim()).FirstOrDefaultAsync();

                var conversion = (value * Convert.ToDecimal(tipoCambio.TipoCambio));

                return conversion;

            }
            catch (Exception ex) {

                throw ex;
            }
        }

        public async Task<List<EMoneda>> ListarAsync()
        {
            try
            {
                return await _dbContext.moneda.ToListAsync();

            }
            catch (Exception ex) {

                throw ex;
            }

        }
    }
}
