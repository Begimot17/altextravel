using AltexTravel.API.Amadeus.Models;
using AltexTravel.API.Amadeus.Models.SearchResult;
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


        public async Task<AmadeusSearchResult> GetSearchResult(string queryParams)
        {
            var Token = await GetToken();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + Token);
            var response = _client.GetAsync(_amadeusConfiguration.UrlSearch + queryParams).GetAwaiter().GetResult();
            var httpResult = await response.Content.ReadAsStringAsync();
            string searchJsonResponce = JsonConvert.DeserializeObject(httpResult).ToString();
            return JsonToAmadeusSearchResultModel(searchJsonResponce);
        }

        public async Task<List<LocationAmadeus>> GetLocations()
        {

            var Token = await GetToken();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + Token);
            var fullLocations = new List<LocationAmadeus>();
            foreach (var key in _amadeusConfiguration.Keywords)
            {
                _amadeusConfiguration.Keyword = key;
                var response = _client.GetAsync(_amadeusConfiguration.UrlLocations).GetAwaiter().GetResult();
                var httpResult = await response.Content.ReadAsStringAsync();
                var locationsJsonResponce = JsonConvert.DeserializeObject(httpResult).ToString();
                fullLocations.AddRange(JsonToAmadeusLocationModel(locationsJsonResponce).Data);
            }
            return fullLocations;
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

        public AmadeusLocationModel JsonToAmadeusLocationModel(string strJson)
        {
            var data = JsonConvert.DeserializeObject<AmadeusLocationModel>(strJson);
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
                            city.Airports.Add(new IataAmadeus { Name = air.Address.Name, Code = air.Address.Code, Country = air.Address.Country});
                        }
                    }
                }
            }
            return data;
        }

        public AmadeusSearchResult JsonToAmadeusSearchResultModel(string strJson)
        {
            var data = JsonConvert.DeserializeObject<AmadeusSearchResult>(strJson);

            return data;
        }
    }
}
