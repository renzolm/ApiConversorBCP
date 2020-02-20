using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conversor.Entity.Entity;
using Conversor.Service.Moneda;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conversor.Api.Controllers.Moneda
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        private readonly IMonedaService _monedaService;
        public MonedaController(IMonedaService monedaService) {
            _monedaService = monedaService;
        }

        // GET: api/Moneda
        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            try {

                var data = await _monedaService.ListarAsync();

                return Ok(data);

            } catch (Exception ex) {

                return Problem(detail: ex.StackTrace, title: ex.Message, statusCode: StatusCodes.Status500InternalServerError);

            }

        }


        [HttpGet]
        [Route("Calcular")]
        public async Task<IActionResult> Post( string origen, string destino, decimal value) 
        {
            try
            {

                var data = await _monedaService.CalcularAsync(origen, destino , value);

                return Ok(data);

            }
            catch (Exception ex)
            {

                return Problem(detail: ex.StackTrace, title: ex.Message, statusCode: StatusCodes.Status500InternalServerError);

            }
        }

      
    }
}
