using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Predictions.Domain.Models
{
    public class FootballScore
    {
        private string _scoreValue;
        public FootballScore()
        {
            Value = string.Empty;
        }
        public FootballScore(string score)
        {
            Value = score;
        }
        public static readonly string ScorePattern = @"^$|^[0-9]{1,2}:[0-9]{1,2}$";
        public string Value
        {
            get 
            { 
                return _scoreValue;
            }
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