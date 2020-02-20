using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

namespace Conversor.RestClient.Util
{
    public static class AppClient
    {
        public static readonly MediaTypeHeaderValue ApplicationJson = MediaTypeHeaderValue.Parse("application/json");
        private static HttpRequestMessage request = null;
        public static HttpRequestMessage RestRequest(string url, HttpMethod method, string token)
        {

            request = new HttpRequestMessage(method, url);
            request.Headers.Add("cache-control", "no-cache");
            request.Headers.Add("Authorization", string.Format("Bearer {0}", token));
            request.Headers.Add("Accept", "application/json");
            return request;
        }
        public static void AddParameter(this HttpRequestMessage requestMessage, string name, object value)
        {

            var parameters = new Dictionary<string, string>();

            var reg = new Regex(@"[?&](\w[\w.]*)=([^?&]+)");

            var url = request.RequestUri.OriginalString;

            var matches = reg.Matches(url);

            foreach (Match match in matches)
            {
                parameters[match.Groups[1].Value] = Uri.UnescapeDataString(match.Groups[2].Value);
            }

            parameters.Add(name, value?.ToString());

            var urlEncodedString = new FormUrlEncodedContent(parameters).ReadAsStringAsync().GetAwaiter().GetResult();

            var length = url.IndexOf("?");

            if (length >= 0) url = url.Substring(0, length);

            if (urlEncodedString.Length > 0) url = string.Format("{0}?{1}", url, urlEncodedString);

            request.RequestUri = new Uri(url, UriKind.Relative);
        }

        public static void AddBody(this HttpRequestMessage requestMessage, object value)
        {
            request.Content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, ApplicationJson.MediaType);
        }

    }
}
