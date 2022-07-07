using System;
using System.Linq;

namespace W5_Project_Team7
{
    public class V2Activities
    {
        public int offset { get; set; }
        public int count { get; set; }
        public V2Activity[] rows { get; set; }
    }


    public class V2Activity
    {
        public string id { get; set; }
        public DateTime updated { get; set; }
        public Descriptions descriptions { get; set; }
        public string duration { get; set; }
        public string durationType { get; set; }
        public Open open { get; set; }
        public Medium[] media { get; set; }
        public ActivityAddress address { get; set; }
        public Company company { get; set; }
        public string[] tags { get; set; }
        public Priceeur priceEUR { get; set; }
        public string[] availableMonths { get; set; }
        public string[] meantFor { get; set; }
        public string siteUrl { get; set; }
        public string storeUrl { get; set; }
        public override string ToString()
        {
            string activityName = descriptions.en is null ? descriptions.fi.name : descriptions.en.name;
            string descriptionToPrint =
                descriptions.en is null ? descriptions.fi.description : descriptions.en.description;
            string whoFor = "";
            if (meantFor.Contains("b2c") && meantFor.Contains("b2b"))
            {
                whoFor = "Individuals, groups and businesses welcome";
            }
            else if (meantFor.Contains("b2c"))
            {
                whoFor = "Individuals and groups welcome.";
            }
            else if (meantFor.Contains("b2b"))
            {
                whoFor = "Businesses welcome";
            }
            
            return $"{activityName}\n" +
                   $"Price from: {priceEUR.from} EUR\n" +
                   $"Price to: {priceEUR.to} EUR\n" +
                   $"Duration: {duration}  {durationType}\n" +
                   $"Address:\n{address.postalCode}\n" +
                   $"{address.streetName}\n" +
                   $"{address.city}\n" +
                   $"{company.email}\n" +
                   $"{company.phone}\n" +
                   $"\n{whoFor}\n" +
                   $"\n{descriptionToPrint}\n" +
                   $"{siteUrl}\n";
        }
    }

    public class Descriptions
    {
        public En? en { get; set; }
        public Fi? fi { get; set; }
        public Fr? fr { get; set; }
        public De? de { get; set; }
        public Es? es { get; set; }
        public It? it { get; set; }
        public Ru? ru { get; set; }
        public Sv? sv { get; set; }
        public Ja? ja { get; set; }
        public Zh? zh { get; set; }
    }

    public class En
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Fi
    {
        public string name { get; set; }
        public string description { get; set; }
    }
    public class Fr
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class De
    {
        public string name { get; set; }
        public string description { get; set; }
    }
    public class Es
    {
        public string name { get; set; }
        public string description { get; set; }
    }
    public class It
    {
        public string name { get; set; }
        public string description { get; set; }
    }
    public class Ru
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Sv
    {
        public string name { get; set; }
        public string description { get; set; }
    }
    public class Ja
    {
        public string name { get; set; }
        public string description { get; set; }
    }
    public class Zh
    {
        public string name { get; set; }
        public string description { get; set; }
    }
    public class Open
    {
        public Sunday sunday { get; set; }
        public Tuesday tuesday { get; set; }
        public Wednesday wednesday { get; set; }
        public Monday monday { get; set; }
        public Friday friday { get; set; }
        public Thursday thursday { get; set; }
        public Saturday saturday { get; set; }
    }

    public class Sunday
    {
        public bool open { get; set; }
        public object from { get; set; }
        public object to { get; set; }
    }

    public class Tuesday
    {
        public bool open { get; set; }
        public object from { get; set; }
        public object to { get; set; }
    }

    public class Wednesday
    {
        public bool open { get; set; }
        public object from { get; set; }
        public object to { get; set; }
    }

    public class Monday
    {
        public bool open { get; set; }
        public object from { get; set; }
        public object to { get; set; }
    }

    public class Friday
    {
        public bool open { get; set; }
        public object from { get; set; }
        public object to { get; set; }
    }

    public class Thursday
    {
        public bool open { get; set; }
        public object from { get; set; }
        public object to { get; set; }
    }

    public class Saturday
    {
        public bool open { get; set; }
        public object from { get; set; }
        public object to { get; set; }
    }

    public class ActivityAddress
    {
        public ActivityLocation location { get; set; }
        public string postalCode { get; set; }
        public string streetName { get; set; }
        public string city { get; set; }
    }

    public class ActivityLocation
    {
        public double? lat { get; set; }
        public double? _long { get; set; }

    }

    public class Company
    {
        public string name { get; set; }
        public string businessId { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    public class Priceeur
    {
       
        public double? from { get; set; }
        public double? to { get; set; }
        public string? pricingType { get; set; }
        
    }

    public class Medium
    {
        public string id { get; set; }
        public string kind { get; set; }
        public string copyright { get; set; }
        public string name { get; set; }
        public string alt { get; set; }
        public string originalUrl { get; set; }
        public string smallUrl { get; set; }
        public string largeUrl { get; set; }
    }

}
