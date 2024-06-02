using System;
class Activity
{
    public DateTime Date { get; private set; }
    public int LengthInMinutes { get; private set; }

    public Activity(DateTime date, int lengthInMinutes)
    {
        Date = date;

        LengthInMinutes = lengthInMinutes;
    }
    public virtual double GetDistance()
    {
        return 0; 
    }

    public virtual double GetSpeed()
    {
        return 0; 
    }

    public virtual double GetPace()
    {
        return 0; 
    }

    public virtual string GetSummary()
    {
        return $"{Date.ToString("MMM dd yyyy")} - {LengthInMinutes} min";
    }
}
class Running : Activity
{
    public double DistanceInMiles { get; private set; }

    public Running(DateTime date, int lengthInMinutes, double distanceInMiles)
        : base(date, lengthInMinutes)
    {
        DistanceInMiles = distanceInMiles;
    }

    public override double GetDistance()
    {
        return DistanceInMiles;
    }

    public override double GetSpeed()
    {
        return DistanceInMiles / (LengthInMinutes / 60.0);
    }

    public override double GetPace()
    {
        return LengthInMinutes / DistanceInMiles;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Running - Distance: {DistanceInMiles:F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F2} min/mile";
    }
}

class Cycling : Activity
{
    public double SpeedInKph { get; private set; }

    public Cycling(DateTime date, int lengthInMinutes, double speedInKph)
        : base(date, lengthInMinutes)
    {
        SpeedInKph = speedInKph;
    }

    public override double GetSpeed()
    {
        return SpeedInKph;
    }

    public override double GetDistance()
    {
        // Speed (km/h) * time (hourss)
        return SpeedInKph * (LengthInMinutes / 60.0);
    }
    public override double GetPace()
    {
        // minutos per kilometer.
        return 60.0 / SpeedInKph; 
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Cycling - Speed: {SpeedInKph:F1} kph, Distance: {GetDistance():F1} km, Pace: {GetPace():F2} min/km";
    }
}

class Swimming : Activity
{
    public int Laps { get; private set; }

    public Swimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        // Converting meters to kilometers
        return Laps * 50 / 1000.0; 
    }

    public override double GetSpeed()
    {
        // kilometers per hour
        return GetDistance() / (LengthInMinutes / 60.0); 
    }

    public override double GetPace()
    {
        // minutes per kilometer
        return 60.0 / GetSpeed(); 
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Swimming - Laps: {Laps}, Distance: {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min/km";
    }
}

class Program
{
    static void Main(string[] args)
    {
        var activities = new Activity[]
        {
            new Running(new DateTime(2024, 5, 1), 30, 3.0),
            new Running(new DateTime(2024, 5, 1), 30, 4.8),
            new Cycling(new DateTime(2024, 5, 2), 45, 20.0),
            new Swimming(new DateTime(2024, 5, 3), 60, 15)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
