using System;
using System.Text.RegularExpressions;

namespace Domain.Models
{
    public class FootballScore
    {
        public static readonly string ScorePattern = @"^$|^[0-9]{1,2}:[0-9]{1,2}$";
        private string _scoreValue;

        public FootballScore()
        {
            Value = string.Empty;
        }

        public FootballScore(string score)
        {
            Value = score;
        }

        public string Value
        {
            get => _scoreValue;
            set
            {
                if (Regex.IsMatch(value, ScorePattern))
                {
                    _scoreValue = value;
                }
                else
                {
                    throw new ArgumentException("Invalide score.");
                }
            }
        }
    }
}