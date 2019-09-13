using AltexTravel.API.DAL.Features.IataCodes;
using AltexTravel.API.DAL.Features.Locations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace AltexTravel.API.Amadeus.BLL
{

    public static class AmadeusManager
    {
        public static List<IataCode> GetIatas()
        {
            var Iatas = new List<IataCode>();
            foreach (var item in GetLocations())
            {
                if (item.Airports != null)
                {

                    Iatas.AddRange(item.Airports);
                }
            }
            return Iatas;
        }
        public static List<Location> GetLocations()
        {
            const string URL = "https://test.api.amadeus.com/v1/reference-data/locations?subType=AIRPORT,CITY&keyword=r&page[limit]=1000";
            string token = GetToken();
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "");
            Task<HttpResponseMessage> response = client.SendAsync(request);
            string myJsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Result.Content.ReadAsStringAsync().Result).ToString();
            client.Dispose();
            return JsonToAmadeusModel(myJsonResponse).Data.ToLocations();

        }

        private static string GetToken()
        {
            const string apikey = "gZCS7tiyaRIIVihAoQFo2vARev7AnAVh";
            const string apisecret = "yb3SXyWAeLGblN8K";
            const string tokenURL = "https://test.api.amadeus.com/v1/security/oauth2/token";

            string postData = $"grant_type=client_credentials&client_id={apikey}&client_secret={apisecret}";
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(tokenURL)
            };

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "")
            {
                Content = new StringContent(postData,
                                    Encoding.UTF8,
                                    "application/x-www-form-urlencoded")
            };

            Task<HttpResponseMessage> response = client.SendAsync(request);
            if (response.Result.IsSuccessStatusCode)
            {
                string myJsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Result.Content.ReadAsStringAsync().Result).ToString();
                JObject jsonObject = JObject.Parse(myJsonResponse);
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
            var airports = new List<IataAmadeus>();
            airports = data.Data.Where(x => x.Type == "AIRPORT").ToIataAmadeus();
            if (airports!=null)
            {
                foreach (var city in data.Data.Where(x => x.Type == "CITY"))
                {
                    city.Airports = new List<IataAmadeus>();
                    foreach (var air in airports)
                    {
                        if (air.Code == city.Code )
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
