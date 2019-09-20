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
        private readonly HttpClient _client;

        private AmadeusConfiguration _amadeusConfiguration;


        public AmadeusManager(AmadeusConfiguration amadeusConfiguration)
        {
            _amadeusConfiguration = amadeusConfiguration;
            _client = new HttpClient { BaseAddress = new Uri(_amadeusConfiguration.BaseUrl) };
        }

        public async Task<List<LocationAmadeus>> GetLocations()
        {

            var Token = await GetToken();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + Token);
            var fullLocations = new List<AmadeusLocationModel>();
            foreach (var key in _amadeusConfiguration.Keywords)
            {
                _amadeusConfiguration.Keyword = key;
                var response = await _client.GetAsync(_amadeusConfiguration.UrlLocations);
                var httpResult = await response.Content.ReadAsStringAsync();
                var locationsJsonResponce = JsonConvert.DeserializeObject(httpResult).ToString();
                fullLocations.Add(JsonToAmadeusLocationModel(locationsJsonResponce));
            }
            return IataIntoLocation(fullLocations);
        }

        private async Task<string> GetToken()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _amadeusConfiguration.TokenUrl)
            {
                Content = new StringContent(_amadeusConfiguration.TokenUrlQuery,
                                    Encoding.UTF8,
                                    "application/x-www-form-urlencoded")
            };

            var response = _client.SendAsync(request);
            if (response.Result.IsSuccessStatusCode)
            {
                var jsonResponse = JsonConvert.DeserializeObject(await response.Result.Content
                    .ReadAsStringAsync()).ToString();
                var jsonObject = JObject.Parse(jsonResponse);
                var token = (string)jsonObject["access_token"];
                return token;
            }
            else
            {
                return response.Result.ReasonPhrase;
            }
        }

        public AmadeusLocationModel JsonToAmadeusLocationModel(string strJson) =>
            JsonConvert.DeserializeObject<AmadeusLocationModel>(strJson);

        public List<LocationAmadeus> IataIntoLocation(List<AmadeusLocationModel> data)
        {
            var locations = data.SelectMany(x => x.Data).ToList();

            locations = locations.Distinct(new ComparerLocationAmadeus()).ToList();
            var airports = locations.Where(x => x.Type == LocationsEnum.AIRPORT.ToString()).ToList();
            if (airports.Count != 0)
            {
                foreach (var city in locations.Where(x => x.Type == LocationsEnum.CITY.ToString()).ToList())
                {
                    city.Airports = new List<IataAmadeus>();
                    foreach (var air in airports)
                    {
                        if (air.Address.Code == city.Address.Code)
                        {
                            city.Airports.Add(new IataAmadeus { Name = air.Name, Code = air.Code, Country = air.Address.Country });
                        }
                    }

                }
            }
            return locations;
        }
    }
}
