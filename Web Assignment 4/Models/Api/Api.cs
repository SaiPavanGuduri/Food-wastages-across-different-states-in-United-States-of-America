using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Web_Assignment_4.Models.Api
{
    public class ApiHelper
    {
        private string Key => "iqvZZyffZfbRPwej5dY7mXOac7SQAq8wfo0pUpkt";
        private string BaseUrl => "https://api.fda.gov/food/enforcement.json";
        private HttpClient httpClient { get; set; }

        public ApiHelper()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<ReportApiResult>> Get(string q)
        {
            var url= $"{BaseUrl}?search={q}";
            httpClient.Timeout = TimeSpan.FromMinutes(10);
            var response = await httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ReportRootobject>(json);
            return result?.results;
        }

        public async Task<List<FoodApiObject>> Get(string q, int count)
        {
            var url = $"{BaseUrl}?search=state:{q}&limit={count}";
            httpClient.Timeout = TimeSpan.FromMinutes(10);
            var response = await httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiRootobject>(json);
            return result?.results;
        }




    }
}
