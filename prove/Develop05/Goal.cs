using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        public string Description { get; set; }
        public int Points { get; set; }

        public Goal(string description, int points)
        {
            Description = description;
            Points = points;
        }

        public abstract int RecordEvent();
        public virtual string GetDetailsString()
        {
            return $"{Description} ({Points} points)";
        }

        public override string ToString()
        {
            return $"{GetType().Name}:{Description}:{Points}";
        }

        public static Goal FromString(string goalString)
        {
            if (string.IsNullOrWhiteSpace(goalString))
            {
                throw new ArgumentException("Goal string cannot be null or whitespace");
            }

            string[] parts = goalString.Split(':');
            Console.WriteLine($"Parsing goal string: {goalString}");
            Console.WriteLine($"Parts length: {parts.Length}");

            if (parts.Length < 3)
            {
                throw new ArgumentException("Invalid goal string format");
            }

            string type = parts[0];
            string description = parts[1];
            if (!int.TryParse(parts[2], out int points))
            {
                throw new ArgumentException("Invalid points value");
            }

            switch (type)
            {
                case nameof(SimpleGoal):
                    return new SimpleGoal(description, points);
                case nameof(EternalGoal):
                    return new EternalGoal(description, points);
                case nameof(ChecklistGoal):
                    if (parts.Length != 6)
                    {
                        throw new ArgumentException("Invalid ChecklistGoal string format");
                    }
                    if (!int.TryParse(parts[3], out int targetCount) ||
                        !int.TryParse(parts[4], out int bonusPoints) ||
                        !int.TryParse(parts[5], out int currentCount))
                    {
                        throw new ArgumentException("Invalid ChecklistGoal values");
                    }
                    return new ChecklistGoal(description, points, targetCount, bonusPoints) { CurrentCount = currentCount };
                default:
                    throw new ArgumentException("Unknown goal type");
            }
        }
    }
}
