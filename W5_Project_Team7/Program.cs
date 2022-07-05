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
            string url = "http://open-api.myhelsinki.fi/v1/events/";

            try
            {
                using (var client = APIHelper.GetHttpClient(url))
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string json = await response.Content.ReadAsStringAsync();


                        V1Events results = JsonSerializer.Deserialize<V1Events>(json);

                        foreach (var item in results.data)
                        {
                            Console.WriteLine("ID: " + item.id + " Name: " + item.name.fi);
                        }

                        Console.WriteLine($"Found {results.meta.count} items.");
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
