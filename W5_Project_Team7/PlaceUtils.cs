using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Text.Json;




namespace W5_Project_Team7
{
    class Program1
    {
       
        public static bool CheckArea(V2Place helsinkiPlace)
        {
            string[] neighbourhoods = new[]
            {
                "Kluuvi", "Kamppi", "Kruununhaka", "Punavuori", "Ullanlinna", "Kallio", "Vallila", "Eira",
                "Kaivopuisto", "Etu - Töölö", "Sörnäinen"
            };
            return neighbourhoods.Contains(helsinkiPlace.location.address.neighbourhood);
        }

        static async Task PrintNameByLocation()
        {
            string url = "http://open-api.myhelsinki.fi/v2/places/";

            try
            {
                using (var client = APIHelper.GetHttpClient(url))
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        V2Places results = JsonSerializer.Deserialize<V2Places>(json);

                        foreach (var helsinkiPlaces in results.data)
                        {
                            try
                            {
                                Console.WriteLine($"Company name: {helsinkiPlaces.name.fi} Location of place: {helsinkiPlaces.location.address.neighbourhood}");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Company: {helsinkiPlaces.location.address.neighbourhood}, no match");
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

        static async Task BarByLocation()
        {
            string url = "http://open-api.myhelsinki.fi/v2/places/";
            try
            {
                using (var client = APIHelper.GetHttpClient(url))
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        V2Places results = JsonSerializer.Deserialize<V2Places>(json);

                        Console.WriteLine("  What type of bar are you searching for? Select type by choosing a number \n" +
                            "  1. Beer \n" +
                            "  2. Wine \n" +
                            "  3. Cocktail bar\n");

                        int input = int.Parse(Console.ReadLine());

                        V2Place helsinkiPlaces = new V2Place();
                        {
                            foreach (var helsinkiBars in results.data)
                            {
                                bool CheckArea = true;

                                if (CheckArea == true && input == 1)
                                {
                                    if (helsinkiBars.tags.Select(x => x.name).Contains("Beer"))
                                    {
                                        Console.WriteLine($"  Name of a bar: {helsinkiBars.name.en}");
                                    }

                                }
                                if (CheckArea == true && input == 2)
                                {
                                    if (helsinkiBars.tags.Select(x => x.name).Contains("Wine"))
                                    {
                                        Console.WriteLine($"  Name of a wine bar: {helsinkiBars.name.en}");
                                    }

                                }
                                if (CheckArea == true && input == 3)
                                {
                                    if (helsinkiBars.tags.Select(x => x.name).Contains("Cocktail"))
                                    {
                                        Console.WriteLine($"  Name of a cocktail bar: {helsinkiBars.name.en}");
                                    }

                                }
                            }

                        }


                    }
                    else
                    {
                        Console.WriteLine("No match for your search. ");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static async Task RestaurantByLocation()
        {
            string url = "http://open-api.myhelsinki.fi/v2/places/";
            try
            {
                using (var client = APIHelper.GetHttpClient(url))
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        V2Places results = JsonSerializer.Deserialize<V2Places>(json);

                        Console.WriteLine("  What would you like to eat? Select food by choosing a number \n" +
                            "  1. Pizza \n" +
                            "  2. Sushi \n" +
                            "  3. Vegetarian\n" +
                            "  4. Hamburger \n" +
                            "  5. Steak  \n" +
                            "  6. Street food \n");
                        int input = int.Parse(Console.ReadLine());

                        V2Place helsinkiPlaces = new V2Place();
                        {
                            foreach (var helsinkiRestaurants in results.data)
                            {
                                bool CheckArea = true;

                                if (CheckArea == true && input == 1)
                                {
                                    if (helsinkiRestaurants.tags.Select(x => x.name).Contains("Pizza"))
                                    {
                                        Console.WriteLine($"  Name of a pizza place: {helsinkiRestaurants.name.en}");
                                    }
                                }
                                if (CheckArea == true && input == 2)
                                {
                                    if (helsinkiRestaurants.tags.Select(x => x.name).Contains("Sushi"))
                                    {
                                        Console.WriteLine($"  Name of a sushi place: {helsinkiRestaurants.name.en}");
                                    }
                                }
                                if (CheckArea == true && input == 3)
                                {
                                    if (helsinkiRestaurants.tags.Select(x => x.name).Contains("Vegetarian"))
                                    {
                                        Console.WriteLine($"  Restaurant name: {helsinkiRestaurants.name.en}");
                                    }
                                }
                                if (CheckArea == true && input == 4)
                                {
                                    if (helsinkiRestaurants.tags.Select(x => x.name).Contains("Hamburger"))
                                    {
                                        Console.WriteLine($"  Name of a hamburger place: {helsinkiRestaurants.name.en}");
                                    }
                                }
                                if (CheckArea == true && input == 5)
                                {
                                    if (helsinkiRestaurants.tags.Select(x => x.name).Contains("Steak"))
                                    {
                                        Console.WriteLine($"  Name of a steak restaurant: {helsinkiRestaurants.name.en}");
                                    }
                                }
                                if (CheckArea == true && input == 6)
                                {
                                    if (helsinkiRestaurants.tags.Select(x => x.name).Contains("Street food"))
                                    {
                                        Console.WriteLine($"  Restaurant name: {helsinkiRestaurants.name.en}");
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("No match for your search. Please select a valid option.");
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
