using System;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace W5_Project_Team7
{
    class Program
    {
        static async Task Main(string[] args)
        {
<<<<<<< HEAD


=======
>>>>>>> 471f6190ef13f3ab9421863266b4904d181a5d1b
            //otsikontulostusmetodia kutsutaan
            bool programRunning = true;

            while (programRunning)
            {
                Console.Clear();

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

                        //string url = "https://open-api.myhelsinki.fi/v2/places/";
                        //etsipaikka - ravintola

                        await PlaceUtils.RestaurantByLocation();
                        break;
                    case 2:
                        //string url = "https://open-api.myhelsinki.fi/v2/places/";
                        //etsipaikka - baari

                        await PlaceUtils.BarByLocation();
                        break;
                    case 3:
                        //string url = "https://open-api.myhelsinki.fi/v2/places/";
                        //etsipaikka - nähtävyys
                        break;
                    case 4:
                        //string url = "https://open-api.myhelsinki.fi/v2/places/";
                        //etsipaikka - shoppailu
                        await ShowPlaces();
                        break;
                    case 5:
                        var response = await APIHelper.RunAsync<V2Activities>("https://open-api.myhelsinki.fi/v2/activities");
                        ActivityUtils.FindActivity(response);
                        break;
                    case 6:
                        //string url = "https://open-api.myhelsinki.fi/v1/events/";

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
<<<<<<< HEAD
<<<<<<< HEAD

            

            


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
=======
>>>>>>> 471f6190ef13f3ab9421863266b4904d181a5d1b
        }




        

=======
                        }
       
>>>>>>> d2ee9267f9ef24cd6e03a9abee785a9fa04a19ae
    }
}
                    
                

            

           
        
     
    

