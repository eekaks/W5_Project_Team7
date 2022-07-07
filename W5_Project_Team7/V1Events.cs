using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace W5_Project_Team7
{
    public class V1Events
    {
        public Meta meta { get; set; }
        public List<V1Event> data { get; set; }
        public Tag[] tagsarray { get; set; }
    }
    public class V1Event
    {
        public string id { get; set; }
        public Name name { get; set; }
        #nullable enable
        public Sourcetype? sourceType { get; set; }
        #nullable disable
        public string info_url { get; set; }
        public DateTime modified_at { get; set; }
        public Location location { get; set; }
        public Description description { get; set; }
        public Tag[] tags { get; set; }
        public Eventdates event_dates { get; set; }
        public override string ToString()
        {
            string eventName = name.en is null ? name.fi : name.en;
            string informationUrl = info_url is null ? "" : info_url;
            string startingDay = event_dates.starting_day is null
                ? "Starting date not specified."
                : DateTime.Parse(event_dates.starting_day).ToShortDateString() + " " + DateTime.Parse(event_dates.starting_day).TimeOfDay;
            string endingDay = event_dates.ending_day is null
                ? "Ending date not specified."
                : DateTime.Parse(event_dates.ending_day).ToShortDateString() + " " + DateTime.Parse(event_dates.ending_day).TimeOfDay;


            string[] toReplace = {"<p>", "</p>", "<strong>", "</strong>", "<h1>", "</h1>", "<h2>", "</h2>",
                "<h3>", "</h3>","<a>","</a>",@"<a href=\", "<br>", "</br>", "&nbsp", @"<a href=", "<b>", "</b>", "<em>", "</em>", ">"};
            string[] temp = description.body.Split(toReplace, StringSplitOptions.RemoveEmptyEntries);
            string fixedDescription = String.Join(" ", temp);

            return String.Format("{0}\n" +
                                 "{1}\n" +
                                 "{2}\n" +
                                 "{3}\n" +
                                 "{4}\n" +
                                 "\n{5}\n" +
                                 "\n{6}\n" +
                                 "\nEvent starts: {7}\n" +
                                 "Event ends: {8}\n", eventName, informationUrl, location.address.street_address, location.address.postal_code,
                location.address.locality, description.intro, fixedDescription, startingDay, endingDay);
        }
    }

    public class Eventdates
    {
#nullable enable
        public string? starting_day { get; set; }

        public string? ending_day { get; set; }

        public Additionaldescription[]? additionalDescription { get; set; }
#nullable disable
    }

    public class Additionaldescription
    {
        public string langCode { get; set; }
        public string text { get; set; }
    }

}

