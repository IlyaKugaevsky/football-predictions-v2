using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Domain.PointSystems;
using Domain.QueryExtensions;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class Prediction : Entity
    {
        private PredictionResult GeneratePredictionResult()
        {
            if (!IsClosed) return PredictionResult.NotYetAssigned;
            if (Score) return PredictionResult.ScoreGuessed;
            if (Difference) return PredictionResult.DifferenceGuessed;
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (Outcome) return PredictionResult.OutcomeGuessed;
            return PredictionResult.NothingGuessed;
        }

        private void UpdatePredictionParameters(PredictionResult predictionResult)
        {
            switch (predictionResult)
            {
                case PredictionResult.NothingGuessed:
                    Score = false;
                    Difference = false;
                    Outcome = false;
                    break;
                case PredictionResult.OutcomeGuessed:
                    Score = false;
                    Difference = false;
                    Outcome = true;
                    break;
                case PredictionResult.DifferenceGuessed:
                    Score = false;
                    Difference = true;
                    Outcome = true;
                    break;
                case PredictionResult.ScoreGuessed:
                    Score = true;
                    Difference = true;
                    Outcome = true;
                    break;
                case PredictionResult.NotYetAssigned:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(predictionResult), predictionResult, null);
            }
        }

        protected Prediction()
        {
        }

        internal Prediction(int id, int expertId, string value, int sum, bool score, bool difference, bool outcome, bool isClosed)
        {
            Id = id;
            ExpertId = expertId;
            Value = value;
            Sum = sum;
            Score = score;
            Difference = difference;
            Outcome = outcome;
            IsClosed = isClosed;
        }

        internal void AttachMatch(Match match)
        {
            Match = match;
        }


        public Prediction(int expertId, int matchId, string value)
        {
            ExpertId = expertId;
            MatchId = matchId;
            Value = value;
        }

        public void SetScore(int homeGoals, int awayGoals)
        {
            Value = FootballScoreProcessor.CreateScoreExpr(homeGoals, awayGoals);
        }

        public string Value { get; private set; }

        public int Sum { get; private set; }
        public bool Score { get; private set; }
        public bool Difference { get; private set; }
        public bool Outcome { get; private set; }

        public bool IsClosed { get; private set; }
        public bool IsPlayoff { get; private set; } = false;

        public int MatchId { get; private set; }
        public Match Match { get; private set; }

        public Expert Expert { get; private set; } = null;
        public int ExpertId { get; private set; }

        public PredictionResult Result => GeneratePredictionResult();
    }
}