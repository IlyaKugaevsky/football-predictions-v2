using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace ReadModel.Features.Experts.Dtos
{
    public class ExpertTourResultsReadDto
    {
        public string Nickname { get; }

        public int Outcomes { get; }
        public int Differences { get; }
        public int Scores { get; }
        public int Sum { get; }

        public ExpertTourResultsReadDto(int tourNumber, string nickname, PredictionsResult predictionsResult, int sum)
        {
            Nickname = nickname;

            Outcomes = predictionsResult.Outcomes;
            Differences = predictionsResult.Differences;
            Scores = predictionsResult.Scores;

            Sum = sum;
        }
    }
}
