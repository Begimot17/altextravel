using AltexTravel.API.Amadeus.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AltexTravel.API.Amadeus
{
    public class AmadeusManager
    {
        private AmadeusConfiguration _amadeusConfiguration;
        private readonly HttpClient Client;
        public AmadeusManager(AmadeusConfiguration amadeusConfiguration)
        {
            _amadeusConfiguration = amadeusConfiguration;
            Client = new HttpClient {BaseAddress= new Uri(_amadeusConfiguration.BaseUrl) };
        }

        public List<IataAmadeus> GetIatas()
        {
            var Iatas = new List<IataAmadeus>();
            foreach (var item in GetLocations())
            {
                Iatas.AddRange(item?.Airports);
            }
            return Iatas;
        }

        public List<LocationAmadeus> GetLocations()
        {
            string token = GetToken();
            Client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
            var response = Client.GetAsync(_amadeusConfiguration.UrlLocations).GetAwaiter().GetResult();
            var httpResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            string locationsJsonResponce = JsonConvert.DeserializeObject(httpResult).ToString();
            return JsonToAmadeusModel(locationsJsonResponce).Data;
        }

        private string GetToken()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _amadeusConfiguration.TokenUrl)
            {
                Content = new StringContent(_amadeusConfiguration.TokenUrlQuery,
                                    Encoding.UTF8,
                                    "application/x-www-form-urlencoded")
            };

            var response = Client.SendAsync(request);
            if (response.Result.IsSuccessStatusCode)
            {
                string jsonResponse = JsonConvert.DeserializeObject(response.Result.Content
                    .ReadAsStringAsync().GetAwaiter().GetResult()).ToString();
                var jsonObject = JObject.Parse(jsonResponse);
                string token = (string)jsonObject["access_token"];
                return token;
            }
            else
            {
                return response.Result.ReasonPhrase;
            }
        }
        public AmadeusModel JsonToAmadeusModel(string strJson)
        {
            var data = JsonConvert.DeserializeObject<AmadeusModel>(strJson);
            var airports = data.Data.Where(x => x.Type == LocationsEnum.AIRPORT.ToString()).ToList();
            if (airports.Count != 0)
            {
                foreach (var city in data.Data.Where(x => x.Type == LocationsEnum.CITY.ToString()).ToList())
                {
                    city.Airports = new List<IataAmadeus>();
                    foreach (var air in airports)
                    {
                        if (air.Address.Code == city.Address.Code)
                        {
                            city.Airports.Add(new IataAmadeus { Name = air.Address.Name, Code = air.Address.Code, Country = air.Address.Country });
                        }
                    }
                }
            }
            return data;
        }
    }
}
