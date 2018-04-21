using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Domain.Services;

namespace Domain.Models
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class Match : Entity
    {
        private readonly List<Prediction> _predictions
            = new List<Prediction>();

        private string _score = string.Empty;

        protected Match()
        {
        }

        internal Match(int matchId, int tourId, Team homeTeam, Team awayTeam, DateTime date)
            : this(tourId, homeTeam.Id, awayTeam.Id, date)
        {
            Id = matchId;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }

        public Match(int tourId, int homeTeamId, int awayTeamId, DateTime date)
        {
            TourId = tourId;
            Date = date;
            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
        }

        public Team HomeTeam { get; private set; }
        public int HomeTeamId { get; private set; }

        public Team AwayTeam { get; private set; }
        public int AwayTeamId { get; private set; }

        // ReSharper disable UnusedAutoPropertyAccessor.Local
        public Tour Tour { get; private set; }
        public int TourId { get; private set; }

        public DateTime Date { get; private set; }

        public bool IsOver => _score.Length != 0;

        public int HomeGoals => IsOver ? FootballScoreProcessor.ExtractHomeGoals(_score) : 0;
        public int AwayGoals => IsOver ? FootballScoreProcessor.ExtractAwayGoals(_score) : 0;

        public IEnumerable<Prediction> Predictions => _predictions.AsReadOnly();

        public void SetScore(int homeGoals, int awayGoals)
        {
            _score = FootballScoreProcessor.CreateScoreExpr(homeGoals, awayGoals);
        }

        public void Close() => throw new NotImplementedException();
        public void Rollback() => throw new NotImplementedException();

        public int GetPredictionsSum()
        {
            if (Predictions == null)
            {
                throw new NullReferenceException(nameof(Predictions));
            }

            return Predictions.Select(p => p.Sum).Sum();
        }
    }
}