using System;
using System.Collections.Generic;
using System.Linq;

namespace W5_Project_Team7
{
    class EventUtils
    {
        public static List<V1Event> FindEventByDate(V1Events events)
        {
            List<V1Event> foundEvents = new List<V1Event>();
            DateTime date = UserUI.GetDateTime();

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
            string searchInput = "";

            while (true)
            {
                Console.WriteLine("Enter search word to find events: ");
                searchInput = Console.ReadLine();
                if (searchInput == "")
                {
                    Console.WriteLine("Invalid input. Try again. ");
                }
                else
                {
                    break;
                }
            }

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
                else
                {
                    foreach (Tag tag in helsinkiEvent.tags)
                    {
                        if (tag.name.ToLower().Contains(searchInput.ToLower()))
                        {
                            foundSearchEvents.Add(helsinkiEvent);
                            break;
                        }
                    }
                }
            }

            if (!foundSearchEvents.Any())
            {
                Console.WriteLine("No events found!");
            }
            return foundSearchEvents;
        }
    }
}
