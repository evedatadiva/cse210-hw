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
            string[] parts = goalString.Split(':');
            string type = parts[0];
            string description = parts[1];
            int points = int.Parse(parts[2]);

            switch (type)
            {
                case nameof(SimpleGoal):
                    return new SimpleGoal(description, points);
                case nameof(EternalGoal):
                    return new EternalGoal(description, points);
                case nameof(ChecklistGoal):
                    int targetCount = int.Parse(parts[3]);
                    int bonusPoints = int.Parse(parts[4]);
                    return new ChecklistGoal(description, points, targetCount, bonusPoints);
                default:
                    throw new ArgumentException("Unknown goal type");
            }
        }
    }
}


