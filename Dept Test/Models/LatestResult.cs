using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Dept_Test.Models
{
    public class LatestResult
    {
        // Splits up meta data and results in a list so list of latest can be used.
        public Meta meta { get; set; }
        public List<Latest> results { get; set; }

        public string errorMessage { get; set; }

        public string cityName { get; set; }

        public bool validateCityName()
        {
            try
            {
                if (cityName != null)
                {
                    string[] words = cityName.Split(" ");
                    for (int i = 0; i < words.Length; i++)
                    {
                        string word = words[i];
                        if (cityName.Length > 1)
                        {
                            words[i] = word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
                        }
                    }
                    cityName = string.Join(" ", words);
                    return true;
                }
                errorMessage = "That city name is not valid. Please check you spelled the city name correctly.";
                return false;
            }
            catch
            {
                errorMessage = "That city name is not valid. Please check you spelled the city name correctly.";
                return false;
            }
        }

        public async Task<bool> getResults()
        {
            try
            {
                HttpClient _client = new HttpClient();
                _client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("SERVER_ADDRESS"));
                string serialisedJson = await _client.GetStringAsync($"/v2/latest?city=" + cityName);
                LatestResult latest = JsonConvert.DeserializeObject<LatestResult>(serialisedJson);
                results = latest.results;
                meta = latest.meta;
                if (meta.found == 0)
                {
                    errorMessage = "No results found for this city name. Please check you spelled the city name correctly.";
                    return false;
                }
                return true;
            }
            catch
            {
                errorMessage = "Error with server client. Please try again later.";
                return false;
            }
        }
    }
}
