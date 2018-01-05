using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Predictions.Domain;

namespace Predictions.Domain.Models
{
    public class Match: Entity
    {
        private readonly List<Prediction> _predictions 
            = new List<Prediction>();

        protected Match() { }
        public Match(int tourId, int homeTeamId, int awayTeamId, DateTime date)
        {
            TourId = tourId;
            Date = date;
            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
            // Score = new FootballScore();
        }
        internal Match(int matchId, int tourId, int homeTeamId, int awayTeamId, DateTime date)
            :this(tourId, homeTeamId, awayTeamId, date)
        {
            Id = matchId;
        }
        public int HomeTeamId { get; private set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; private set; }
        public Team AwayTeam { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; }

        public FootballScore Score { get; private set; } = new FootballScore();
        public DateTime Date { get; private set; }

        public virtual List<Prediction> Predictions { get; set; }

        public int GetPredictionsSum()
        {
            if (Predictions == null) throw new NullReferenceException("Predictions");
            return Predictions.Select(p => p.Sum).Sum();
        }
    }
}