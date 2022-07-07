using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

            bool programRunning = true;

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
                        await RestaurantByLocation();
                        break;
                    case 2:
                        //etsipaikka - baari
                        await BarByLocation();
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


        }

    }
}

                   




