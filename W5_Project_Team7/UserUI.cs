using System;

namespace W5_Project_Team7
{
    class UserUI
    {
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
    }
}
