using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace BrodenSchmeiderAPITest
{
    public class LiveTrafficDataAPIClient
    {
        private static readonly HttpClient client = new HttpClient();
        public string apiKey {get;set;}
        public string apiURL {get;set;}

        public HttpResponseMessage RequestDataFromAPI()
        {
            HttpResponseMessage response = null;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("apikey", apiKey);
            
            try
            {
                response = client.GetAsync(apiURL).Result;
            }
            catch(Exception ex)
            {
                response = null;
            }
            return response;
        }
    }
}
