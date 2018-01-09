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
        }
        internal Match(int matchId, int tourId, int homeTeamId, int awayTeamId, DateTime date)
            :this(tourId, homeTeamId, awayTeamId, date)
        {
            Id = matchId;
        }
        public int HomeTeamId { get; private set; }
        public Team HomeTeam { get; private set; }

        public int AwayTeamId { get; private set; }
        public Team AwayTeam { get; private set; }

        public int TourId { get; private set; }
        public Tour Tour { get; private set; }

        public DateTime Date { get; private set; }
        public FootballScore Score { get; private set; } 
            = new FootballScore();

        public IEnumerable<Prediction> Predictions => _predictions.AsReadOnly();

        public int GetPredictionsSum()
        {
            if (Predictions == null) throw new NullReferenceException(nameof(Predictions));
            return Predictions.Select(p => p.Sum).Sum();
        }
    }
}