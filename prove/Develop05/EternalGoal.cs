namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string description, int points) : base(description, points) { }

        public override int RecordEvent()
        {
            return Points;
        }
    }
}

