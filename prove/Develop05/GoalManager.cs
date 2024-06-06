using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> goals = new List<Goal>();
        private int score = 0;

        public void AddGoal(Goal goal)
        {
            goals.Add(goal);
        }

        public void RecordEvent(int index)
        {
            if (index >= 0 && index < goals.Count)
            {
                score += goals[index].RecordEvent();
            }
        }

        public int GetScore()
        {
            return score;
        }

        public void DisplayGoals()
        {
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals to display.");
            }
            else
            {
                for (int i = 0; i < goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
                }
            }
        }

        public void SaveGoals(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(score);
                foreach (Goal goal in goals)
                {
                    writer.WriteLine(goal.ToString());
                }
            }
        }

        public void LoadGoals(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    score = int.Parse(reader.ReadLine());
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Goal goal = Goal.FromString(line);
                        goals.Add(goal);
                    }
                }
            }
        }
    }
}

