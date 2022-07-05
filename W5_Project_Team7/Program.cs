using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace W5_Project_Team7
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://open-api.myhelsinki.fi/v2/activities";

            try
            {
                using (var client = APIHelper.GetHttpClient(url))
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string json = await response.Content.ReadAsStringAsync();


                        //V2Activities results = JsonSerializer.Deserialize<V2Activities>(json);

                        


                        //Console.WriteLine($"Found {results.count} items.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
