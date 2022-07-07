<<<<<<< HEAD
﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Text.Json;

=======
﻿using System.Linq;
>>>>>>> 471f6190ef13f3ab9421863266b4904d181a5d1b

namespace W5_Project_Team7
{
    class PlaceUtils
    {
<<<<<<< HEAD

        //Tulostaa shoppailupaikat tagin mukaan
        public static async Task ShowPlaces()
        {
            string url = "https://open-api.myhelsinki.fi/v2/places/";

            try
            {
                using (var client = APIHelper.GetHttpClient(url))
                {
                    //Lähettää kutsun apille
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        //Lukee apin sisällön
                        var json = await response.Content.ReadAsStringAsync();

                        //Luodaan olio
                        V2Places result = JsonSerializer.Deserialize<V2Places>(json);

                        Console.WriteLine("You want to go shopping? What are you looking for? Select an option below: \n" +
                            "1) Shoes \n" +
                            "2) Bags \n" +
                            "3) Kids clothing \n" +
                            "4) Souvenirs");
                        int answer = int.Parse(Console.ReadLine());

                        foreach (var item in result.data)
                        {
                            string[] neighbourhoods = new[]
                            {
                                "Kluuvi", "Kamppi", "Kruununhaka", "Punavuori", "Ullanlinna", "Kallio", "Vallila", "Eira",
                                "Kaivopuisto", "Etu - Töölö", "Sörnäinen"
                            };

                            if (answer == 1)
                            {
                                if (item.tags.Select(x => x.name).Contains("Shoes"))
                                {
                                    if (neighbourhoods.Contains(item.location.address.neighbourhood))
                                    {
                                        Console.WriteLine("Company name: " + item.name.en);
                                    }

                                }

                            }
                            if (answer == 2)
                            {
                                if (item.tags.Select(x => x.name).Contains("Bags"))
                                {
                                    if (neighbourhoods.Contains(item.location.address.neighbourhood))
                                    {
                                        Console.WriteLine("Company name: " + item.name.en);
                                    }
                                }

                            }
                            if (answer == 3)
                            {
                                if (item.tags.Select(x => x.name).Contains("Kids clothing"))
                                {
                                    if (neighbourhoods.Contains(item.location.address.neighbourhood))
                                    {
                                        Console.WriteLine("Company name: " + item.name.en);
                                    }
                                }

                            }
                            if (answer == 4)
                            {
                                if (item.tags.Select(x => x.name).Contains("Souvenirs"))
                                {
                                    if (neighbourhoods.Contains(item.location.address.neighbourhood))
                                    {
                                        Console.WriteLine("Company name: " + item.name.en);
                                    }
                                }

                            }

                        }

                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }


        //Tulostaa nähtävyydet tagin mukaan
        public static async Task ShowSights()
        {
            string url = "https://open-api.myhelsinki.fi/v2/places/";

            try
            {
                using (var client = APIHelper.GetHttpClient(url))
                {
                    //Lähettää kutsun apille
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        //Lukee apin sisällön
                        var json = await response.Content.ReadAsStringAsync();

                        //Luodaan olio
                        V2Places result = JsonSerializer.Deserialize<V2Places>(json);

                        Console.WriteLine("You wanna go sight seeing? What are you looking for? Select an option below: \n" +
                            "1) Parks \n" +
                            "2) Museums \n" +
                            "3) Church \n" +
                            "4) Architecture");
                        int answer = int.Parse(Console.ReadLine());

                        foreach (var item in result.data)
                        {
                            string[] neighbourhoods = new[]
                            {
                                "Kluuvi", "Kamppi", "Kruununhaka", "Punavuori", "Ullanlinna", "Kallio", "Vallila", "Eira",
                                "Kaivopuisto", "Etu - Töölö", "Sörnäinen"
                            };

                            if (answer == 1)
                            {
                                if (item.tags.Select(x => x.name).Contains("Park"))
                                {
                                    if (neighbourhoods.Contains(item.location.address.neighbourhood))
                                    {
                                        Console.WriteLine("Name: " + item.name.en);
                                    }

                                }

                            }
                            if (answer == 2)
                            {
                                if (item.tags.Select(x => x.name).Contains("museum"))
                                {
                                    if (neighbourhoods.Contains(item.location.address.neighbourhood))
                                    {
                                        Console.WriteLine("Name: " + item.name.en);
                                    }
                                }

                            }
                            if (answer == 3)
                            {
                                if (item.tags.Select(x => x.name).Contains("Church"))
                                {
                                    if (neighbourhoods.Contains(item.location.address.neighbourhood))
                                    {
                                        Console.WriteLine("Name: " + item.name.en);
                                    }
                                }

                            }
                            if (answer == 4)
                            {
                                if (item.tags.Select(x => x.name).Contains("Architecture"))
                                {
                                    if (neighbourhoods.Contains(item.location.address.neighbourhood))
                                    {
                                        Console.WriteLine("Name: " + item.name.en);
                                    }
                                }

                            }

                        }

                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
=======
        public static bool CheckArea(V2Place helsinkiPlace)
        {
            string[] neighbourhoods = new[]
            {
                "Kluuvi", "Kamppi", "Kruununhaka", "Punavuori", "Ullanlinna", "Kallio", "Vallila", "Eira",
                "Kaivopuisto", "Etu - Töölö", "Sörnäinen"
            };
            return neighbourhoods.Contains(helsinkiPlace.location.address.neighbourhood);
>>>>>>> 471f6190ef13f3ab9421863266b4904d181a5d1b
        }
    }
}
