using System;
using System.Text.RegularExpressions;

namespace Domain.Services
{
    public static class FootballScoreProcessor
    {
        private const string FootballScorePattern = @"^[0-9]{1,2}:[0-9]{1,2}$";

        private static bool IsValidGoalsNumber(int goalsNumber) 
            => (goalsNumber >= 0) && (goalsNumber <= 99);

        private static void ValidateInputExpr(string input)
        {
            if (!IsValidScoreExpr(input))
            {
                throw new ArgumentException("Invalid input for score processing.");
            }
        }

        public static bool IsValidScoreExpr(string str)
            => Regex.IsMatch(str, FootballScorePattern);

        public static int ExtractHomeGoals(string scoreExpr)
        {
            ValidateInputExpr(scoreExpr);
            return int.Parse(scoreExpr.Split(':')[0]);
        }

        public static int ExtractAwayGoals(string scoreExpr)
        {
            ValidateInputExpr(scoreExpr);
            return int.Parse(scoreExpr.Split(':')[1]);
        }

        public static Tuple<int, int> ExtractGoals(string scoreExpr)
        {
            ValidateInputExpr(scoreExpr);
            return new Tuple<int, int>(ExtractHomeGoals(scoreExpr), ExtractAwayGoals(scoreExpr));
        }

        public static string CreateScoreExpr(int homeGoals, int awayGoals)
        {
            if (!IsValidGoalsNumber(homeGoals))
            {
                throw new ArgumentException($"The number of home goals is out of range.");
            }
            if (!IsValidGoalsNumber(awayGoals))
            {
                throw new ArgumentException($"The number of away goals is out of range.");
            }

            return string.Join(":", homeGoals.ToString(), awayGoals.ToString());
        }
    }
}
