using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Text.Json;


namespace W5_Project_Team7
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "http://open-api.myhelsinki.fi/v2/activities";

            try
            {
                using (var client = APIHelper.GetHttpClient(url))
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string json = await response.Content.ReadAsStringAsync();


                        V2Activities results = JsonSerializer.Deserialize<V2Activities>(json);

                        foreach (var item in results.rows)
                        {
                            if (!(item.descriptions.en is null))
                            {
                                Console.WriteLine("Company name: " + item.company.name + "\nDescription: " + item.descriptions.en.name);
                            }
                            else if (!(item.descriptions.fi is null))
                            {
                                Console.WriteLine("Company name: " + item.company.name + "\nDescription: " + item.descriptions.fi.name);
                            }
                        }
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
