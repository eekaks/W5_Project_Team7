using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
                        break;
                    case 2:
                        //string url = "https://open-api.myhelsinki.fi/v2/places/";
                        //etsipaikka - baari
                        break;
                    case 3:
                        //string url = "https://open-api.myhelsinki.fi/v2/places/";
                        //etsipaikka - nähtävyys
                        break;
                    case 4:
                        //string url = "https://open-api.myhelsinki.fi/v2/places/";
                        //etsipaikka - shoppailu
                        break;
                    case 5:
                        var response = await APIHelper.RunAsync<V2Activities>("https://open-api.myhelsinki.fi/v2/activities");
                        FindActivity(response);
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
        public static DateTime GetDateTime()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter date in the following format: 'YYYY/mm/dd'");
                    DateTime input = DateTime.Parse(Console.ReadLine());
                    return input;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input. Try again.");
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
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                PrintBanner("ACTIVITIES");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("So, you want to find something to do!");
                Console.WriteLine("\n1 - find all activities\n2 - search for specific activities\n3 - search for activities by price\n4 - search for activities open today\n0 - exit");
                int inputChoice;
                while (true)
                {
                    try
                    {
                        inputChoice = int.Parse(Console.ReadLine());
                        if (inputChoice < 0 || inputChoice > 4)
                        {
                            Console.WriteLine("Invalid input. Try again.");
                            
                            continue;
                        }
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid input. Try again.");
                    }
                }
                if (inputChoice == 1)
                {
                    ChooseOneActivity(activities.rows.ToList());
                }
                else if (inputChoice == 2)
                {
                    string searchWord;
                    while (true)
                    {
                        Console.WriteLine("Enter one search word to find activities. Use English: ");
                        searchWord = Console.ReadLine();
                        if (searchWord == "" || searchWord is null || searchWord.Contains(" "))
                        {
                            Console.WriteLine("Invalid input. Try again.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey(true);
                            continue;
                        }
                        break;
                    }
                    
                    List<V2Activity> foundActivities = new List<V2Activity>();

                    foreach (V2Activity helsinkiActivity in activities.rows)
                    {
                        if (!(helsinkiActivity.descriptions.en is null))
                        {
                            if (helsinkiActivity.descriptions.en.name.ToLower().Contains(searchWord.ToLower()) ||
                                helsinkiActivity.descriptions.en.description.ToLower().Contains(searchWord.ToLower()) ||
                                helsinkiActivity.tags.Contains(searchWord.ToLower()))
                            {
                                foundActivities.Add(helsinkiActivity);
                            }
                        }
                        else
                        {
                            foreach (string tag in helsinkiActivity.tags)
                            {
                                if (tag.Contains(searchWord))
                                {
                                    foundActivities.Add(helsinkiActivity);
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
                        ChooseOneActivity(foundActivities);
                    }
                }
                else if (inputChoice == 3)
                {
                    int priceLimit;
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

                    List<V2Activity> foundActivities = new List<V2Activity>();

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
                    if (!foundActivities.Any())
                    {
                        Console.WriteLine("No activities found - press any key to continue.");
                        Console.ReadKey(true);
                        continue;
                    }
                    ChooseOneActivity(foundActivities);
                }
                else if (inputChoice == 4)
                {
                    List<V2Activity> foundActivities = new List<V2Activity>();
                    foreach (V2Activity helsinkiActivity in activities.rows)
                    {
                        if (IsActivityOpenToday(helsinkiActivity))
                        {
                            foundActivities.Add(helsinkiActivity);
                        }
                    }
                    if (!foundActivities.Any())
                    {
                        Console.WriteLine("No activities found - press any key to continue.");
                        Console.ReadKey(true);
                        continue;
                    }
                    ChooseOneActivity(foundActivities);
                }
                else if (inputChoice == 0)
                {
                    break;
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
            return false;
        }
        public static void PrintBanner(string title)
        {
            int emptiesLeft = (59 - title.Length) / 2;
            int emptiesRight = (59 - title.Length) / 2;
            if (title.Length % 2 != 0)
            {
                emptiesRight -= 1;
            }
            Console.WriteLine(new string('*', 60));
            Console.WriteLine("*" + new string(' ', emptiesLeft) + title + new string(' ', emptiesRight) + "*");
            Console.WriteLine(new string('*', 60) + "\n");
        }

        public static void ChooseOneActivity(List<V2Activity> foundActivities)
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
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    PrintBanner("ACTIVITY");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(foundActivities[choice]);
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey(true);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input. Try again.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey(true);
                }
            }
                        }
       
    }
}
                    
                

            

           
        
     
    

