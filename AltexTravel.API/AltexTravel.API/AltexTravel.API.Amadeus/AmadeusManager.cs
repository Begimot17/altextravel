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

        private string Token;
        public AmadeusManager(AmadeusConfiguration amadeusConfiguration)
        {
            _amadeusConfiguration = amadeusConfiguration;
            _client = new HttpClient { BaseAddress = new Uri(_amadeusConfiguration.BaseUrl) };
        }

        public async Task<List<LocationAmadeus>> GetLocationsAsync()
        {
            await GetToken();
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

        public async Task<AmadeusSearchResult> GetSearchResultAsync(string queryParams)
        {
            await GetToken();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + Token);
            var response = await _client.GetAsync(_amadeusConfiguration.UrlSearch + queryParams);
            var httpResult = await response.Content.ReadAsStringAsync();
            string searchJsonResponce = JsonConvert.DeserializeObject(httpResult).ToString();
            return JsonToAmadeusSearchResultModel(searchJsonResponce);
        }

        private async Task<bool> GetToken()
        {
            if (Token != null || Token != "Bad Request")
            {
                return true;
            }
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

                Token = (string)jsonObject["access_token"];
                return true;
            }
            else
            {
                Token = null;
                return false;
            }
        }

        public AmadeusLocationModel JsonToAmadeusLocationModel(string strJson) =>
            JsonConvert.DeserializeObject<AmadeusLocationModel>(strJson);

        public AmadeusSearchResult JsonToAmadeusSearchResultModel(string strJson) =>
            JsonConvert.DeserializeObject<AmadeusSearchResult>(strJson);

        public List<LocationAmadeus> IataIntoLocation(List<AmadeusLocationModel> data)
        {
            var locations = data.SelectMany(x => x.Data).ToList();

            locations = locations.Distinct(new AmadeusLocationComparer()).ToList();
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
