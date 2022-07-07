using System;

namespace W5_Project_Team7
{
    //tässä tiedostossa on metodeja koodareilta Maria Toivanen ja Eetu Laine (merkitty alle)
    class UserUI
    {
        //Maria Toivanen
        public static void MainBanner()
        {

            Console.WriteLine(@"                      
                                        
                           |                                   |
                           T                                  /^\                        _.-(__)-.__
                          ( )                               /*****\                    (__)  |   (__)
                          <==>                       |     (_______)    |             /  \   |   /   \__
                         /\/\/\                     /o\    |       |   /o\         (__)   \  |  /    (__)
                        J{}{}{}F         .         (   )   (¤¤¤O¤¤¤)  (   )        J  `-.  \ | /  .-'  L
                     .  F{}{}{}J         T         I   I  I¤¤¤O¤¤¤¤¤I I   I      .-+.____`-.\|/.-'____.+-.
                     T J{}{}{}{}F        ;;       /_______________________\      `-+'     .-/|\`-.    `+-'
                    /|\F \/ \/ \J  .   ,;;;;.     ||£ ||¤ ||€ || || ||¤||£||       J_  .-' / | \  `-. _F
                  .'/|\\:========F T ./;;;;;;\´   ||  ||  ||  || || || || ||_____ (__)'   /  |  \    (__)
                 ///|||\\\        /   \\\///// |¤¤||  ||  ||  || || || || ||¤¤¤¤¤|   `.__/   |   \__.'
                 \\\\|////..[]...     |||||||  |  ||  ||  ||  || || || || ||     |    (__)   |_  (__)
                 |¤¤¤¤¤¤|.:||[] |/    |||||||  |  ||  ||  ||  || || || || ||     |        `-.(__)-' 
                 |      |\        |   |     |  |  ||  ||  ||  || || || || ||     |         /    \
              ____________________________________________________________________________________________________
                                              _    _      _     _       _    _ 
                                             | |  | |    | |   (_)     | |  (_)
                                             | |__| | ___| |___ _ _ __ | | ___ 
                                             |  __  |/ _ \ / __| | '_ \| |/ / |
                                             | |  | |  __/ \__ \ | | | |   <| |
                                             |_|  |_|\___|_|___/_|_| |_|_|\_\_|

        ");
        }

        //Eetu Laine
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

        //Eetu Laine
        public static void PrintBanner(string title)
        {
            int emptiesLeft = (129 - title.Length) / 2;
            int emptiesRight = (129 - title.Length) / 2;
            if (title.Length % 2 != 0)
            {
                emptiesRight -= 1;
            }
            Console.WriteLine(new string('*', 130));
            Console.WriteLine("*" + new string(' ', emptiesLeft) + title + new string(' ', emptiesRight) + "*");
            Console.WriteLine(new string('*', 130) + "\n");
        }
    }
}
