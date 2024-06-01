using System;
using System.Collections.Generic;
class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public string GetFullAddress()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}
abstract class Event
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public string Time { get; private set; }
    public Address Address { get; private set; }
    public Event(string title, string description, DateTime date, string time, Address address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Address = address;
    }
    public virtual string GetStandardDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nAddress: {Address.GetFullAddress()}";
    }

    public abstract string GetFullDetails();
    
    public virtual string GetShortDescription()
    {
        return $"Event Type: {GetType().Name}\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
    }
}
class Lecture : Event
{
    public string Speaker { get; private set; }
    public int Capacity { get; private set; }

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        Speaker = speaker;
        Capacity = capacity;
    }
    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }
}

class Reception : Event
{
    public string RSVP { get; private set; }

    public Reception(string title, string description, DateTime date, string time, Address address, string rsvp)
        : base(title, description, date, time, address)
    {
        RSVP = rsvp;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Reception\nRSVP: {RSVP}";
    }
}

class OutdoorGathering : Event
{
    public string Weather { get; private set; }

    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        Weather = weather;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather: {Weather}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "NY", "USA");
        Address address2 = new Address("456 Maple Ave", "Othertown", "CA", "USA");
        Address address3 = new Address("789 Oak Blvd", "Thistown", "TX", "USA");

        List<Event> events = new List<Event>
        {
            new Lecture("Lecture", "Introduction of the lecture.", new DateTime(2024, 6, 1), "10:00 AM", address1, "Dr. John Doe", 100),
            new Reception("Wedding Reception", "Join us for a wedding celebration", new DateTime(2024, 6, 15), "6:00 PM", address2, "rsvp@wedding.com"),
            new OutdoorGathering("Picnic in the Park", "Family-friendly picnic", new DateTime(2024, 7, 4), "12:00 PM", address3, "Sunny")
        };

        foreach (var eventItem in events)
        {
            Console.WriteLine(eventItem.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(eventItem.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(eventItem.GetShortDescription());
            Console.WriteLine(new string('-', 40));
        }
    }
}
