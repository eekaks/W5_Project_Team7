using System;
using System.Collections.Generic;
using System.Linq;

namespace W5_Project_Team7
{
    //tämän tiedoston teki Eetu Laine
    class ActivityUtils
    {
        public static void FindActivity(V2Activities activities)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                UserUI.PrintBanner("ACTIVITIES");
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
                    UserUI.PrintBanner("ACTIVITY");
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
