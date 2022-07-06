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
            string url = "https://open-api.myhelsinki.fi/v1/events/";
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
                        V1Events results = JsonSerializer.Deserialize<V1Events>(json);

                        Console.WriteLine("Let's find you events to attend! From which day would you like to look events?");
                        Console.WriteLine("A - From today. B - From a specific date");

                        string answer = Console.ReadLine().ToLower();
                        DateTime startDate = DateTime.Now;

                        if (answer is "a")
                        {
                            startDate = DateTime.Today;
                        }

                        else if (answer is "b")
                        {
                            Console.WriteLine("What date would you like to look for?");
                            startDate = DateTime.Parse(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine("Please choose A or B.");
                        }

                        Console.WriteLine("Do you want to specify an end date? Answer yes or no.");
                        string answerTwo = Console.ReadLine().ToLower();
                        DateTime endDate = DateTime.Now;

                        if (answerTwo is "yes")
                        {
                            Console.WriteLine("What date would you like it to end?");
                            endDate = DateTime.Parse(Console.ReadLine());
                        }

                        else if (answerTwo is "no")
                        {
                            Console.WriteLine("Okay, showing you all the upcoming events within the next 6 months.");
                            endDate = DateTime.Today.AddMonths(6);
                        }

                        var dayRangeEvents = results.data.Where(e => e.event_dates.starting_day >= startDate && e.event_dates.ending_day <= endDate);
                        Console.WriteLine("The upcoming events during this time are:");
                        foreach (var item in dayRangeEvents)

                        {
                            Console.WriteLine($"\nEvent name: {item.name.en} {item.name.fi}\nEvent location: {item.location.address.street_address}\nWhat the event is about: {item.description.intro}");

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
                if (date >= helsinkiEvent.event_dates.starting_day && date <= helsinkiEvent.event_dates.ending_day)
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

            

           
        
     
    

