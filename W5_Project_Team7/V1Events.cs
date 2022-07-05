using System;
using System.Collections.Generic;

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
        public Sourcetype? sourceType { get; set; }
        public string infoUrl { get; set; }
        public DateTime modifiedAt { get; set; }
        public Location location { get; set; }
        public Description description { get; set; }
        public Tag[] tags { get; set; }
        public Eventdates eventDates { get; set; }
    }

    public class Eventdates
    {
        public DateTime startingDay { get; set; }
        public DateTime endingDay { get; set; }
        public Additionaldescription[] additionalDescription { get; set; }
    }

    public class Additionaldescription
    {
        public string langCode { get; set; }
        public string text { get; set; }
    }

}

