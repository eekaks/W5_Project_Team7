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
            string url = "https://open-api.myhelsinki.fi/v1/events/";

            try
            {
                using (var client = APIHelper.GetHttpClient(url))
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        //V2Places places = JsonSerializer.Deserialize<V2Places>(json);
                        //V2Activities results = JsonSerializer.Deserialize<V2Activities>(json);
                        V1Events events = JsonSerializer.Deserialize<V1Events>(json);

                        //foreach (V1Event helsinkiEvent in FindEventByDate(events))
                        //{
                        //    Console.WriteLine(helsinkiEvent.name.fi);
                        //}

                        foreach (V1Event helsinkiEvent in events.data)
                        {
                            Console.WriteLine(helsinkiEvent.event_dates.starting_day);
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
        public static DateTime GetDateTime()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter a date in the following format: 'YYYY/mm/dd'");
                    DateTime input = DateTime.Parse(Console.ReadLine());
                    return input;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            }
        }
    }
}
