using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Conversor.Client.Models;
using Conversor.RestClient.Moneda;

namespace Conversor.Client.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMonedaRestClient _monedaRestClient;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMonedaRestClient monedaRestClient )
        {
            _logger = logger;
            _monedaRestClient = monedaRestClient;
        }

        public IActionResult Index()
        {
            
            return View();

        }

        public JsonResult Listar() {

            try
            {

                var data = _monedaRestClient.ListarAsync().GetAwaiter().GetResult();

                return Json(data);

            }
            catch (Exception)
            {

                return Json("Error al listar");

            }
        }

        public JsonResult Calcular(string origen, string destino, decimal value) {

            try {

                var data = _monedaRestClient.CalcularAsync(origen, destino, value).GetAwaiter().GetResult();

                return Json(data);

            } catch (Exception) {

                return Json("Error al calcular el tipo de cambio");
            
            }
        
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
