using System;
using System.Threading.Tasks;

namespace W5_Project_Team7
{
    //Tämä tiedosto kasattiin yhdessä, eli Christian Keihäs, Tiia Meriranta, Maria Toivanen ja Eetu Laine
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.SetWindowSize(130, 38);
            bool programRunning = true;

            while (programRunning)
            {
                Console.Clear();
                UserUI.MainBanner();

                Console.WriteLine("\n" + new string(' ', 50) + "1. Find a restaurant\n" +
                                  new string(' ', 50) + "2. Go drink with Finns\n" +
                                  new string(' ', 50) + "3. See the sights\n" +
                                  new string(' ', 50) + "4. Shop 'til you drop\n" +
                                  new string(' ', 50) + "5. Find an activity\n" +
                                  new string(' ', 50) + "6. Take part in an event\n" +
                                  new string(' ', 50) + "0. exit");
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
                        await PlaceUtils.RestaurantByLocation();
                        break;
                    case 2:
                        //etsipaikka - baari
                        await PlaceUtils.BarByLocation();
                        break;
                    case 3:
                        //etsipaikka - nähtävyys
                        await PlaceUtils.ShowSights();
                        break;
                    case 4:
                        //etsipaikka - shoppailu
                        await PlaceUtils.ShowPlaces();
                        break;
                    case 5:
                        var response = await APIHelper.RunAsync<V2Activities>("https://open-api.myhelsinki.fi/v2/activities");
                        ActivityUtils.FindActivity(response);
                        break;
                    case 6:
                        //etsi tapahtuma
                        await EventUtils.EventDateRange();
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
    }
}
                    
                

            

           
        
     
    

