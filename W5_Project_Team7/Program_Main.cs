using System;
using System.Threading.Tasks;


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
                        ActivityUtils.FindActivity(response);
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
    }
}
