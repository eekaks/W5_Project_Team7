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
            string url = "https://open-api.myhelsinki.fi/v2/activities";
            //string url = "https://open-api.myhelsinki.fi/v2/places/";

            try
            {
                using (var client = APIHelper.GetHttpClient(url))
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        //V2Places places = JsonSerializer.Deserialize<V2Places>(json);
                        V2Activities activities = JsonSerializer.Deserialize<V2Activities>(json);
                        //V1Events events = JsonSerializer.Deserialize<V1Events>(json);

                        FindActivity(activities);

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

        public static void FindActivity(V2Activities activities)
        {
            Console.WriteLine("So, you want to find something to do!");
            int priceLimit = int.MaxValue;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter a price limit in EUR: ('0' for no limit)");
                    priceLimit = int.Parse(Console.ReadLine());
                    if (priceLimit == 0)
                    {
                        priceLimit = int.MaxValue;
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }

            Console.WriteLine("Enter a search word to find activities.\nPress enter to enter nothing and see all the activities in your price range. Use English: ");
            string searchWord = Console.ReadLine();

            List<V2Activity> foundActivities = new List<V2Activity>();

            if (searchWord == string.Empty)
            {
                foreach (V2Activity helsinkiActivity in activities.rows)
                {
                    if (helsinkiActivity.priceEUR.from < priceLimit)
                    {
                        foundActivities.Add(helsinkiActivity);
                    }

                    if (helsinkiActivity.priceEUR.from is null)
                    {
                        foundActivities.Add(helsinkiActivity);
                    }
                }
            }
            else
            {
                foreach (V2Activity helsinkiActivity in activities.rows)
                {
                    if (!(helsinkiActivity.descriptions.en is null))
                    {
                        if (helsinkiActivity.descriptions.en.name.ToLower().Contains(searchWord.ToLower()) ||
                            helsinkiActivity.descriptions.en.description.ToLower().Contains(searchWord.ToLower()) ||
                            helsinkiActivity.tags.Contains(searchWord.ToLower()))
                        {
                            if (IsActivityOpenToday(helsinkiActivity))
                            {
                                if (helsinkiActivity.priceEUR.from < priceLimit)
                                {
                                    foundActivities.Add(helsinkiActivity);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (helsinkiActivity.tags.Contains(searchWord))
                        {
                            if (IsActivityOpenToday(helsinkiActivity))
                            {
                                if (helsinkiActivity.priceEUR.from < priceLimit)
                                {
                                    foundActivities.Add(helsinkiActivity);
                                }
                            }
                        }
                    }
                }
            }

            if (!foundActivities.Any())
            {
                Console.WriteLine("No activities found - press any key to continue.");
                Console.ReadKey(true);
            }
            else
            {
                while (true)
                {
                    Console.Clear();
                    for (int i = 0; i < foundActivities.Count(); i++)
                    {
                        string activityName = foundActivities[i].descriptions.en is null
                            ? foundActivities[i].descriptions.fi.name
                            : foundActivities[i].descriptions.en.name;
                        Console.WriteLine($"ID: {i} Activity name: {activityName}");
                    }
                    try
                    {
                        Console.WriteLine("\nWhich activity would you like to know about? Enter ID: ");
                        int choice = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine(foundActivities[choice]);
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey(true);
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid input. Try again.");
                    }
                }
                
            }


        }

        public static bool IsActivityOpenToday(V2Activity helsinkiActivity)
        {
            bool isMonth = false;
            foreach (string month in helsinkiActivity.availableMonths)
            {
                if (month.Contains(DateTime.Now.ToString("MMMM").ToLower()))
                {
                    isMonth = true;
                }
            }

            if (isMonth)
            {
                switch (DateTime.Now.DayOfWeek.ToString())
                {
                    case "Monday":
                        return helsinkiActivity.open.monday.open.Equals(true);
                    case "Tuesday":
                        return helsinkiActivity.open.tuesday.open.Equals(true);
                    case "Wednesday":
                        return helsinkiActivity.open.wednesday.open.Equals(true);
                    case "Thursday":
                        return helsinkiActivity.open.thursday.open.Equals(true);
                    case "Friday":
                        return helsinkiActivity.open.friday.open.Equals(true);
                    case "Saturday":
                        return helsinkiActivity.open.saturday.open.Equals(true);
                    case "Sunday":
                        return helsinkiActivity.open.sunday.open.Equals(true);
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }

            
        }
    }
}
