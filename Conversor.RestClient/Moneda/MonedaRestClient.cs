using Conversor.Entity.Core;
using Conversor.Entity.Entity;
using Conversor.RestClient.Util;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Conversor.RestClient.Moneda
{
   public class MonedaRestClient : IMonedaRestClient
    {
        private string _BaseUrl ;
        public MonedaRestClient(IOptions<Settings> settings) {
            _BaseUrl = settings.Value.BaseUrl;
        }

        public async Task<decimal> CalcularAsync(string origen, string destino, decimal value)
        {

            var _client = new HttpClient();

            var response = await _client.GetAsync(_BaseUrl + string.Format("/api/Moneda/Calcular?origen={0}&destino={1}&value={2}", origen, destino, value));


            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<decimal>(await response.Content.ReadAsStringAsync());
            }
            else
            {

                throw new Exception(await response.Content.ReadAsStringAsync());
            }


            
        }

        public async Task<List<EMoneda>> ListarAsync()
        {
            var _client = new HttpClient();
            _client.BaseAddress = new Uri(_BaseUrl);


            var request = AppClient.RestRequest("api/Moneda/Listar", HttpMethod.Get, null);

            var response = await _client.SendAsync(request);


            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<EMoneda>>(await response.Content.ReadAsStringAsync());
            }
            else
            {

                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
