using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BrodenSchmeiderAPITest
{
    public class LiveTrafficData
    {
        public static LiveTrafficDataResponse.Response RetrieveLiveTrafficData(string apiKey, string URL)
        {
            LiveTrafficDataResponse.Response responseObject = null;

            LiveTrafficDataAPIClient apiClient = new LiveTrafficDataAPIClient();
            apiClient.apiKey = apiKey;
            apiClient.apiURL = URL;

            try
            {
                var response = apiClient.RequestDataFromAPI();

                if (response != null)
                {
                    // this will be false if an invalid api key is sent through to the api
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        responseObject = (LiveTrafficDataResponse.Response)JsonConvert.DeserializeObject(data, typeof(LiveTrafficDataResponse.Response));
                    }
                }
            }
            catch (Exception ex)
            {
                responseObject = null;
            }
            return responseObject;
        }
    }
}
