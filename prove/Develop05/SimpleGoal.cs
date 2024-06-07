using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string description, int points) : base(description, points) { }

        public override int RecordEvent()
        {
            return Points;
        }
    }
}
