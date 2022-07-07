using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Linq;

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
            //string url = "https://open-api.myhelsinki.fi/v2/activities";
            //string url = "https://open-api.myhelsinki.fi/v2/places/";

            //    try
            //    {
            //        using (var client = APIHelper.GetHttpClient(url))
            //        {
            //            HttpResponseMessage response = await client.GetAsync(url);

            //            if (response.StatusCode == HttpStatusCode.OK)
            //            {
            //                string json = await response.Content.ReadAsStringAsync();


            //                V2Activities results = JsonSerializer.Deserialize<V2Activities>(json);

            //                foreach (var item in results.rows)
            //                {
            //                    try
            //                    {
            //                        Console.WriteLine($"Company: {item.company.name}, For who: {item.meantFor[0]}");
            //                    }
            //                    catch (Exception e)
            //                    {
            //                        Console.WriteLine($"Company: {item.company}, Meant for not found");
            //                    }
            //                }

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
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.ToString());
            //}

            //V2Places places = JsonSerializer.Deserialize<V2Places>(json);
            //V2Activities results = JsonSerializer.Deserialize<V2Activities>(json);
            //V1Events events = JsonSerializer.Deserialize<V1Events>(json);

            await EventDateRange();
        }

        static async Task EventTypeSearch(DateTime endDate)
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
                        V1Events events = JsonSerializer.Deserialize<V1Events>(json);

                        Console.WriteLine("What kind of event would you like attend? The categories available are:\n1. Concerts\n2. Theater\n3. (Art) Exhibitions\n4. Sporting events");
                        int eventType = Convert.ToInt32(Console.ReadLine());
                      

                        switch (eventType)
                        {
                            case 1:
                                List<V1Event> concerts = new List<V1Event>();
                                var foundConcerts = events.data.Where(e => e.event_dates.ending_day != null).Where(e => endDate >= DateTime.Parse(e.event_dates.ending_day) 
                                && e.tags.Select(e => e.name).Contains("concerts"));
                                concerts.AddRange(foundConcerts);
                                
                                for (int i = 0; i < concerts.Count; i++)
                                    {
                                      Console.WriteLine($"{i}: {concerts[i].name.en}");
                                    }
                                Console.WriteLine("What event would you like to learn about more? Enter number: ");
                                int choice = int.Parse(Console.ReadLine());
                                Console.WriteLine(concerts[choice]);
                                break;

                            case 2:
                                List<V1Event> theatre = new List<V1Event>();
                                var foundTheatre = events.data.Where(e => e.event_dates.ending_day != null).Where(e => endDate >= DateTime.Parse(e.event_dates.ending_day)
                                && e.tags.Select(e => e.name).Contains("theatre"));
                                theatre.AddRange(foundTheatre);

                                for (int i = 0; i < theatre.Count; i++)
                                {
                                    Console.WriteLine($"{i}: {theatre[i].name.fi}");
                                }
                                Console.WriteLine("What event would you like to learn about more? Enter number: ");
                                int choiceTwo = int.Parse(Console.ReadLine());
                                Console.WriteLine(theatre[choiceTwo]);

                                break;
                            case 3:
                                List<V1Event> exhibitions = new List<V1Event>();
                                var foundExhibitions = events.data.Where(e => e.event_dates.ending_day != null).Where(e => endDate >= DateTime.Parse(e.event_dates.ending_day)
                                && e.tags.Select(e => e.name).Contains("exhibitions"));
                                exhibitions.AddRange(foundExhibitions);

                                for (int i = 0; i < exhibitions.Count; i++)
                                {
                                    Console.WriteLine($"{i}: {exhibitions[i].name.fi}");
                                }
                                Console.WriteLine("What event would you like to learn about more? Enter number: ");
                                int choiceThree = int.Parse(Console.ReadLine());
                                Console.WriteLine(exhibitions[choiceThree]);
                                break;

                            case 4:
                                List<V1Event> sports = new List<V1Event>();
                                var foundSports = events.data.Where(e => e.event_dates.ending_day != null).Where(e => endDate >= DateTime.Parse(e.event_dates.ending_day)
                                && e.tags.Select(e => e.name).Contains("sports"));
                                sports.AddRange(foundSports);

                                for (int i = 0; i < sports.Count; i++)
                                {
                                    Console.WriteLine($"{i}: {sports[i].name.fi}");
                                }
                                Console.WriteLine("What event would you like to learn about more? Enter number: ");
                                int choiceFour = int.Parse(Console.ReadLine());
                                Console.WriteLine(sports[choiceFour]);
                                break;
                        }
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static async Task EventDateRange()
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
                        V1Events events = JsonSerializer.Deserialize<V1Events>(json);

                        Console.WriteLine("Let's find you events to attend! When are you coming to Helsinki?");
                        Console.WriteLine("A - I am here already. B - Specify a day.");

                        string answer = Console.ReadLine().ToLower();
                        DateTime startDate = DateTime.Now;

                        if (answer is "a")
                        {
                            startDate = DateTime.Today;
                        }

                        else if (answer is "b")
                        {
                            Console.WriteLine("What date are you coming? Please write the day in dd/mm/yyyy format.");
                            startDate = DateTime.Parse(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine("Please choose A or B.");
                        }

                        Console.WriteLine("What date are you leaving? Please write the day in dd/mm/yyyy format.");
                        DateTime endDate = DateTime.Parse(Console.ReadLine());

                        List<V1Event> FoundEvents = new List<V1Event>();

                        Console.WriteLine("Would you like to search events through a category or see all ongoing events during your stay?"
                            + "\nA- You want to search specific categories. B- You want to see all events.");
                        string answerTwo = Console.ReadLine().ToLower();

                        if (answerTwo is "a")
                        {
                            
                            await EventTypeSearch(endDate);
                        }

                        else if (answerTwo is "b")
                        {
                            var eventsearch = events.data.Where(e => e.event_dates.ending_day!= null).Where(e => e.event_dates.starting_day!= null).Where(e => startDate >= DateTime.Parse(e.event_dates.starting_day) && endDate <= DateTime.Parse(e.event_dates.ending_day)).ToList();
                            FoundEvents.AddRange(eventsearch);

                            for (int i = 0; i < FoundEvents.Count; i++)
                            {
                                Console.WriteLine($"{i}: {FoundEvents[i].name.fi}");
                            }

                            Console.WriteLine("What event would you like to learn about more? Enter number: ");
                            int choice = int.Parse(Console.ReadLine());
                            Console.WriteLine(FoundEvents[choice]);
                        }

                        else
                        { Console.WriteLine("Please write A or B."); }
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

                    }
                }

            

           
        
     
    

