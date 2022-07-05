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
                            try
                            {
                                Console.WriteLine($"Company: {item.company.name}, For who: {item.descriptions}");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Company: {item.company.name}, For who: {item.descriptions}");
                            }
                        }

                        /*

                        foreach (var item in results.rows)
                        {
                            try
                            {
                                Console.WriteLine("Company name: " + item.company.name + "Description: " + item.descriptions.additionalprop2.name);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Company name: " + item.company.name + "Description not found");
                            }
                        }
                        */
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
