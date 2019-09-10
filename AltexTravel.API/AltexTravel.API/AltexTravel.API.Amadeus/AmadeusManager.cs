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
        private readonly HttpClient _client;
        public AmadeusManager(AmadeusConfiguration amadeusConfigurationProps)
        {
            _client = new HttpClient(/*AmadeusConfiguration.BASE_URL*/);
        }

        public static List<IataAmadeus> GetIatas()
        {
            var Iatas = new List<IataAmadeus>();
            foreach (var item in GetLocations())
            {
                Iatas.AddRange(item?.Airports);
            }
            return Iatas;
        }

        public static List<LocationAmadeus> GetLocations()
        {
            string token = GetToken();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(AmadeusConfiguration.URL);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
                var response = client.GetAsync(string.Empty).GetAwaiter().GetResult();
                string locationsJsonResponce = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().GetAwaiter().GetResult()).ToString();
                return JsonToAmadeusModel(locationsJsonResponce).Data;
            }
        }

        private static string GetToken()
        {
            using (var client = new HttpClient(/*new HttpMessageHandler(AmadeusConfiguration.BASE_URL*/) )
            {
                client.BaseAddress = new Uri(AmadeusConfiguration.TOKEN_URL);
                var request = new HttpRequestMessage(HttpMethod.Post, "")
                {
                    Content = new StringContent(AmadeusConfiguration.PostData,
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
        public static AmadeusModel JsonToAmadeusModel(string strJson)
        {
            var data = JsonConvert.DeserializeObject<AmadeusModel>(strJson);
            var airports = data.Data.Where(x => x.Type == LocationsEnum.AIRPORT.ToString());
            if (airports != null)
            {
                foreach (var city in data.Data.Where(x => x.Type == LocationsEnum.CITY.ToString()))
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
