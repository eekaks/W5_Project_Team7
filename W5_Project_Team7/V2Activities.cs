using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class V2Activities
{
    public int offset { get; set; }
    public int count { get; set; }
    public Row[] rows { get; set; }
}

public class Row
{
    public string id { get; set; }
    public string updated { get; set; }
    public Descriptions descriptions { get; set; }
    public Company company { get; set; }
    public Open open { get; set; }
    public Medium[] media { get; set; }
    public Address address { get; set; }
    public Companyaddress companyAddress { get; set; }
    public string[] tags { get; set; }
    public string siteUrl { get; set; }
    public string storeUrl { get; set; }
    public Priceeur priceEUR { get; set; }
    public string[] availableMonths { get; set; }
    public string[] meantFor { get; set; }
    public string duration { get; set; }
    public string durationType { get; set; }
}

public class Descriptions
{
    public Additionalprop1? additionalprop1 { get; set; }
    public Additionalprop2? additionalprop2 { get; set; }
    public Additionalprop3? additionalprop3 { get; set; }
}

public class Additionalprop1
{
    public string name { get; set; }
    public string description { get; set; }
    public string siteUrl { get; set; }
    public string storeUrl { get; set; }
}

public class Additionalprop2
{
    public string name { get; set; }
    public string description { get; set; }
    public string siteUrl { get; set; }
    public string storeUrl { get; set; }
}

public class Additionalprop3
{
    public string name { get; set; }
    public string description { get; set; }
    public string siteUrl { get; set; }
    public string storeUrl { get; set; }
}

public class Company
{
    public string name { get; set; }
    public string businessId { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
}

public class Open
{
    public Additionalprop11 additionalProp1 { get; set; }
    public Additionalprop21 additionalProp2 { get; set; }
    public Additionalprop31 additionalProp3 { get; set; }
}

public class Additionalprop11
{
    public bool open { get; set; }
    public string from { get; set; }
    public string to { get; set; }
}

public class Additionalprop21
{
    public bool open { get; set; }
    public string from { get; set; }
    public string to { get; set; }
}

public class Additionalprop31
{
    public bool open { get; set; }
    public string from { get; set; }
    public string to { get; set; }
}

public class Companyaddress
{
    public string streetAddress { get; set; }
    public string postalCode { get; set; }
    public string locality { get; set; }
    public string neighbourhood { get; set; }
}


public class Priceeur
{
    public double? from { get; set; }
    public double? to { get; set; }
    public string? pricingType { get; set; }
}


public class From
{
}

public class To
{
}


public class Medium
{
    public string id { get; set; }
    public string kind { get; set; }
    public string copyright { get; set; }
    public string name { get; set; }
    public string alt { get; set; }
    public string smallUrl { get; set; }
    public string originalUrl { get; set; }
    public string largeUrl { get; set; }
}

