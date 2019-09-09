using AltexTravel.API.Amadeus.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
namespace AltexTravel.API.Amadeus
{
    public static class AmadeusManager
    {
        const string URL = "https://test.api.amadeus.com/v1/reference-data/locations?subType=AIRPORT,CITY&keyword=r&page[limit]=1000";
        const string apikey = "gZCS7tiyaRIIVihAoQFo2vARev7AnAVh";
        const string apisecret = "yb3SXyWAeLGblN8K";
        const string tokenURL = "https://test.api.amadeus.com/v1/security/oauth2/token";
        public static List<IataAmadeus> GetIatas()
        {
            var Iatas = new List<IataAmadeus>();
            foreach (var item in GetLocations())
            {
                if (item.Airports != null)
                {

                    Iatas.AddRange(item.Airports);
                }
            }
            return Iatas;
        }
        public static List<LocationAmadeus> GetLocations()
        {
            string token = GetToken();
            var client = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
            var request = new HttpRequestMessage(HttpMethod.Get, "");
            var response = client.SendAsync(request);
            string myJsonResponse = JsonConvert.DeserializeObject(response.Result.Content.ReadAsStringAsync().Result).ToString();
            client.Dispose();
            return JsonToAmadeusModel(myJsonResponse).Data;

        }

        private static string GetToken()
        {
            string postData = $"grant_type=client_credentials&client_id={apikey}&client_secret={apisecret}";
            var client = new HttpClient
            {
                BaseAddress = new Uri(tokenURL)
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "")
            {
                Content = new StringContent(postData,
                                    Encoding.UTF8,
                                    "application/x-www-form-urlencoded")
            };

            var response = client.SendAsync(request);
            if (response.Result.IsSuccessStatusCode)
            {
                string jsonResponse = JsonConvert.DeserializeObject(response.Result.Content.ReadAsStringAsync().Result).ToString();
                var jsonObject = JObject.Parse(jsonResponse);
                client.Dispose();
                string token = (string)jsonObject["access_token"];
                return token;
            }
            else
            {
                return response.Result.ReasonPhrase;
            }
        }
        public static AmadeusModel JsonToAmadeusModel(string strJson)
        {
            var data = JsonConvert.DeserializeObject<AmadeusModel>(strJson);
            var airports = data.Data.Where(x => x.Type == "AIRPORT");
            if (airports != null)
            {
                foreach (var city in data.Data.Where(x => x.Type == "CITY"))
                {
                    city.Airports = new List<IataAmadeus>();
                    foreach (var air in airports)
                    {
                        if (air.Code == city.Code)
                        {
                            city.Airports.Add(new IataAmadeus { Name = air.Name, Code = air.Code });
                        }
                    }
                }
            }
            return data;
        }
    }
}
