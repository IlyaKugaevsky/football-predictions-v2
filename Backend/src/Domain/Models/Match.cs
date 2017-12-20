using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Predictions.Domain.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public string Title { get; set; }
        public string Score { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; }

        public virtual List<Prediction> Predictions { get; set; }

        public Match() { }

        public Match(DateTime date, Team homeTeam, Team awayTeam, Tour tour)
        {
            if (homeTeam == null)
                throw new ArgumentNullException("HomeTeam");

            if (awayTeam == null)
                throw new ArgumentNullException("AwayTeam");

            Date = date;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Tour = tour;
            Score = string.Empty;
        }

        public Match(DateTime date, Team homeTeam, Team awayTeam, int tourId)
        {
            if (homeTeam == null)
                throw new ArgumentNullException("HomeTeam");

            if (awayTeam == null)
                throw new ArgumentNullException("AwayTeam");

            Date = date;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            TourId = tourId;
            Score = string.Empty;
        }

        public Match(DateTime date, int homeTeamId, int awayTeamId, int tourId)
        {
            Date = date;
            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
            TourId = tourId;
            Score = string.Empty;
        }

        public FootballScore GetFootballScore()
        {
            return new FootballScore(Score);
        }

        public int GetPredictionsSum()
        {
            if (Predictions == null) throw new NullReferenceException("Predictions");
            return Predictions.Select(p => p.Sum).Sum();
        }
    }
}