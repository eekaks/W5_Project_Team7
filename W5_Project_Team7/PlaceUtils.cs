using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace W5_Project_Team7
{
    //Tässä tiedostossa on metodeja koodareilta Tiia Meriranta, Christian Keihäs ja Eetu Laine
    class PlaceUtils
    {
        //Tulostaa shoppailupaikat tagin mukaan
        //Christian Keihäs
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
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
        }


        //Tulostaa nähtävyydet tagin mukaan
        //Christian Keihäs
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

                        Console.WriteLine(
                            "You wanna go sight seeing? What are you looking for? Select an option below: \n" +
                            "1) Parks \n" +
                            "2) Museums \n" +
                            "3) Church \n" +
                            "4) Architecture");
                        int answer = int.Parse(Console.ReadLine());

                        foreach (var item in result.data)
                        {
                            string[] neighbourhoods = new[]
                            {
                                "Kluuvi", "Kamppi", "Kruununhaka", "Punavuori", "Ullanlinna", "Kallio", "Vallila",
                                "Eira",
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
                                if (item.tags.Select(x => x.name).Contains("museums"))
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
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
        }

        //Eetu Laine
        public static bool CheckArea(V2Place helsinkiPlace)
        {
            string[] neighbourhoods = new[]
            {
                "Kluuvi", "Kamppi", "Kruununhaka", "Punavuori", "Ullanlinna", "Kallio", "Vallila", "Eira",
                "Kaivopuisto", "Etu - Töölö", "Sörnäinen"
            };
            return neighbourhoods.Contains(helsinkiPlace.location.address.neighbourhood);
        }

        //Tiia Meriranta
        public static async Task PrintNameByLocation()
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
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
        }

        //Tiia Meriranta
        public static async Task BarByLocation()
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
                                    if (helsinkiBars.tags.Select(x => x.name).Contains("Cocktail bar"))
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
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
        }
        //Tiia Meriranta
        public static async Task RestaurantByLocation()
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
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
        }
    }
}
