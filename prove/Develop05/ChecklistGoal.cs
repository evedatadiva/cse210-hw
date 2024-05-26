namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        public int TargetCount { get; set; }
        public int CurrentCount { get; set; }
        public int BonusPoints { get; set; }

        public ChecklistGoal(string description, int points, int targetCount, int bonusPoints)
            : base(description, points)
        {
            TargetCount = targetCount;
            BonusPoints = bonusPoints;
        }

        public override int RecordEvent()
        {
            CurrentCount++;
            if (CurrentCount >= TargetCount)
            {
                CurrentCount = 0; 
                return Points + BonusPoints;
            }
            return Points;
        }

        public override string GetDetailsString()
        {
            return $"{Description} ({Points} points, {CurrentCount}/{TargetCount} completed, {BonusPoints} bonus points)";
        }

        public override string ToString()
        {
            return $"{GetType().Name}:{Description}:{Points}:{TargetCount}:{BonusPoints}:{CurrentCount}";
        }
    }
}

