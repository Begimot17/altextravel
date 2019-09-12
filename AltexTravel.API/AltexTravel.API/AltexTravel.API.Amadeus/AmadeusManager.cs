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
    public class AmadeusManager
    {
        private AmadeusConfiguration _amadeusConfiguration;

        public AmadeusManager(AmadeusConfiguration amadeusConfiguration)
        {
            _amadeusConfiguration = amadeusConfiguration;
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
            using (var client = new HttpClient() { BaseAddress = new Uri(_amadeusConfiguration.UrlLocations) })
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
                var response = client.GetAsync(string.Empty).GetAwaiter().GetResult();
                var httpResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                string locationsJsonResponce = JsonConvert.DeserializeObject(httpResult).ToString();
                return JsonToAmadeusModel(locationsJsonResponce).Data;
            }
        }

        private string GetToken()
        {
            using (var client = new HttpClient() { BaseAddress = new Uri(_amadeusConfiguration.TokenUrl) })
            {
                client.BaseAddress = new Uri(_amadeusConfiguration.TokenUrl);
                var request = new HttpRequestMessage(HttpMethod.Post, "")
                {
                    Content = new StringContent(_amadeusConfiguration.TokenUrlQuery,
                                        Encoding.UTF8,
                                        "application/x-www-form-urlencoded")
                };

                var response = client.SendAsync(request);
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
