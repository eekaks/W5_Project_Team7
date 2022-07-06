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
        #nullable enable
        public Sourcetype? sourceType { get; set; }
        #nullable disable
        public string info_url { get; set; }
        public DateTime modified_at { get; set; }
        public Location location { get; set; }
        public Description description { get; set; }
        public Tag[] tags { get; set; }
        public string[] extra_searchwords { get; set; }
        public string opening_hours_url { get; set; }
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
        #nullable enable
        public int? id { get; set; }
        public string? name { get; set; }
        #nullable disable
    }

    public class Location
    {
        #nullable enable
        public double? lat { get; set; }
        public double? lon { get; set; }
        #nullable disable
        public Address address { get; set; }
    }


    public class Address
    {
        public string street_address { get; set; }
        public string postal_code { get; set; }
        public string locality { get; set; }
#nullable enable
        public string? neighbourhood { get; set; }
#nullable disable
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
        #nullable enable
        public Licensetype? license_type { get; set; }
        public string? media_id { get; set; }
#nullable disable

    }

    public class Licensetype
    {
        #nullable enable
        public int? id { get; set; }
        public string? name { get; set; }
        #nullable disable
    }

    public class Tag
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
