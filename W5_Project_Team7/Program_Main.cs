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
    class Program
    {
        static async Task Main(string[] args)
        {


            //otsikontulostusmetodia kutsutaan
            bool programRunning = false;

            while (programRunning)
            {
                Console.WriteLine("\n1. Find a restaurant\n" +
                                  "2. Go drink with Finns\n" +
                                  "3. See the sights\n" +
                                  "4. Shop 'til you drop\n" +
                                  "5. Find an activity\n" +
                                  "6. Take part in an event\n" +
                                  "0. exit");
                int choice;
                while (true)
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid input. Try again.");
                    }

                switch (choice)
                {
                    case 1:
                        //etsipaikka - ravintola
                        break;
                    case 2:
                        //etsipaikka - baari
                        break;
                    case 3:
                        //etsipaikka - nähtävyys
                        break;
                    case 4:
                        //etsipaikka - shoppailu
                        await ShowPlaces();
                        break;
                    case 5:
                        //etsi aktiviteetti
                        break;
                    case 6:
                        //etsi tapahtuma
                        break;
                    case 0:
                        programRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Try again.");
                        break;

                }
            }

            

            


            //string url = "https://open-api.myhelsinki.fi/v1/events/";
            //string url = "https://open-api.myhelsinki.fi/v2/activities";
            string url = "https://open-api.myhelsinki.fi/v2/places/";


            try
            {
                using (var client = APIHelper.GetHttpClient(url))
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        V2Places places = JsonSerializer.Deserialize<V2Places>(json);
                        //V2Activities activities = JsonSerializer.Deserialize<V2Activities>(json);
                        //V1Events events = JsonSerializer.Deserialize<V1Events>(json);

                        for (int i = 0; i < places.data.Count(); i++)
                        {
                            if (CheckArea(places.data[i]))
                            {
                                Console.WriteLine(places.data[i]);
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

        public static List<V1Event> FindEventByDate(V1Events events)
        {
            List<V1Event> foundEvents = new List<V1Event>();
            DateTime date = GetDateTime();

            foreach (V1Event helsinkiEvent in events.data)
            {
                if (date >= DateTime.Parse(helsinkiEvent.event_dates.starting_day) && date <= DateTime.Parse(helsinkiEvent.event_dates.ending_day))
                {
                    foundEvents.Add(helsinkiEvent);
                }
            }
            return foundEvents;
        }

        public static List<V1Event> FindEventBySearchWordAndDate(V1Events events)
        {
            List<V1Event> foundEvents = FindEventByDate(events);
            Console.WriteLine("Syötä hakusana etsiäksesi tapahtumia: ");
            string searchInput = Console.ReadLine();

            List<V1Event> foundSearchEvents = new List<V1Event>();

            foreach (V1Event helsinkiEvent in foundEvents)
            {
                if (helsinkiEvent.name.fi.ToLower().Contains(searchInput.ToLower()))
                {
                    foundSearchEvents.Add(helsinkiEvent);
                }
                else if (helsinkiEvent.description.intro.ToLower().Contains(searchInput.ToLower()))
                {
                    foundSearchEvents.Add(helsinkiEvent);
                }
                else if (helsinkiEvent.description.body.ToLower().Contains(searchInput.ToLower()))
                {
                    foundSearchEvents.Add(helsinkiEvent);
                }

                foreach (Tag tag in helsinkiEvent.tags)
                {
                    if (tag.name.ToLower().Contains(searchInput.ToLower()))
                    {
                        foundSearchEvents.Add(helsinkiEvent);
                    }
                }
            }

            if (!foundSearchEvents.Any())
            {
                Console.WriteLine("Ei löytynyt tapahtumia!");
            }
            return foundSearchEvents;
        }
        public static DateTime GetDateTime()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Syötä päivämäärä seuraavassa muodossa: 'YYYY/mm/dd'");
                    DateTime input = DateTime.Parse(Console.ReadLine());
                    return input;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Virheellinen syöte, yritä uudestaan.");
                }
            }
        }

        public static bool CheckArea(V2Place helsinkiPlace)
        {
            string[] neighbourhoods = new[]
            {
                "Kluuvi", "Kamppi", "Kruununhaka", "Punavuori", "Ullanlinna", "Kallio", "Vallila", "Eira",
                "Kaivopuisto", "Etu - Töölö", "Sörnäinen"
            };
            return neighbourhoods.Contains(helsinkiPlace.location.address.neighbourhood);
        }




        //Näyttää shoppailupaikat tagien mukaan
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
                            if (answer == 1)
                            {
                                if (item.tags.Select(x => x.name).Contains("Shoes"))
                                {
                                    Console.WriteLine("Company name: " + item.name.en);
                                }

                            }
                            if (answer == 2)
                            {
                                if (item.tags.Select(x => x.name).Contains("Bags"))
                                {
                                    Console.WriteLine("Company name: " + item.name.en);
                                }

                            }
                            if (answer == 3)
                            {
                                if (item.tags.Select(x => x.name).Contains("Kids clothing"))
                                {
                                    Console.WriteLine("Company name: " + item.name.en);
                                }

                            }
                            if (answer == 4)
                            {
                                if (item.tags.Select(x => x.name).Contains("Souvenirs"))
                                {
                                    Console.WriteLine("Company name: " + item.name.en);
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




        //Näyttää ravintolat tagien mukaan
        public static async Task ShowRestaurants()
        {
            string url = "https://open-api.myhelsinki.fi/v2/places/";

            try
            {
                using (var client = APIHelper.GetHttpClient(url))
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        //Lukee apin sisällön
                        var json = await response.Content.ReadAsStringAsync();

                        //Luodaan olio
                        V2Places result = JsonSerializer.Deserialize<V2Places>(json);

                        Console.WriteLine("You want to eat? What are you looking for? Select an option below: \n" +
                            "1) Pizza \n" +
                            "2) Sushi \n" +
                            "3) Hamburger \n" +
                            "4) Asian");
                        int answer = int.Parse(Console.ReadLine());

                        foreach (var item in result.data)
                        {
                            if (answer == 1)
                            {
                                if (item.tags.Select(x => x.name).Contains("Pizza"))
                                {
                                    Console.WriteLine("Company name: " + item.name.en);
                                }

                            }
                            if (answer == 2)
                            {
                                if (item.tags.Select(x => x.name).Contains("Sushi"))
                                {
                                    Console.WriteLine("Company name: " + item.name.en);
                                }

                            }
                            if (answer == 3)
                            {
                                if (item.tags.Select(x => x.name).Contains("Hamburger"))
                                {
                                    Console.WriteLine("Company name: " + item.name.en);
                                }

                            }
                            if (answer == 4)
                            {
                                if (item.tags.Select(x => x.name).Contains("Asian"))
                                {
                                    Console.WriteLine("Company name: " + item.name.en);
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

    }
}
