using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace W5_Project_Team7

{
    public static class APIHelper
    {
        public static HttpClient GetHttpClient(string url, string urlParams)
        {
            var client = new HttpClient { BaseAddress = new Uri(url) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }

}
