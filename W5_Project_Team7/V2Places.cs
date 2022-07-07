using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace W5_Project_Team7
{
    public class V2Places
    {
        public Meta meta { get; set; }
        public List<V2Place> data { get; set; }
        public Tag[] tagsarray { get; set; }
    }

    public class Meta
    {
        public string count { get; set; }
    }
    public class V2Place
    {
        public string id { get; set; }
        public Name name { get; set; }
        public Sourcetype? sourceType { get; set; }
        public string info_url { get; set; }
        public DateTime modified_at { get; set; }
        public Location location { get; set; }
        public Description description { get; set; }
        public Tag[] tags { get; set; }
        public string[] extra_searchwords { get; set; }

        public string opening_hours_url { get; set; }

        public override string ToString()
        {
            string placeName = name.en is null ? name.fi : name.en;
            return String.Format("{0}\n" +
                                 "{1}\n" +
                                 "{2}\n" +
                                 "{3}\n" +
                                 "{4}\n" +
                                 "{5}\n" +
                                 "\n{6}\n", placeName, info_url, location.address.street_address, location.address.postal_code,
                location.address.locality, location.address.neighbourhood, description.body);
        }

    }

    public class Name
    {
        public string fi { get; set; }
        public string en { get; set; }
        public string sv { get; set; }
        public string zh { get; set; }
    }

    public class Sourcetype
    {
        public int? id { get; set; }
        public string? name { get; set; }
    }

    public class Location
    {
        public double? lat { get; set; }
        public double? lon { get; set; }
        public Address address { get; set; }
    }


    public class Address
    {
        public string street_address { get; set; }
        public string postal_code { get; set; }
        public string locality { get; set; }
        public string? neighbourhood { get; set; }
    }

    public class Description
    {
        public string intro { get; set; }
        public string body { get; set; }
        public Image[] images { get; set; }
    }

    public class Image

    {
        public string url { get; set; }
        public string copyright_holder { get; set; }
        public Licensetype? license_type { get; set; }
        public string? media_id { get; set; }

    }

    public class Licensetype
    {
        public int? id { get; set; }
        public string? name { get; set; }
       
    }

    public class Tag
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
