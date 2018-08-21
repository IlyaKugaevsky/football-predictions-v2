using System;
using System.Collections.Generic;
using System.Text;
using WriteModel.Features.Predictions.Dtos;

namespace WriteModel.Features.Teams.Dtos
{
    public class ExpertPredictionsWriteDto
    {
        public ExpertPredictionsWriteDto(string nickname, IEnumerable<PredictionWriteDto> predictions)
        {
            Nickname = nickname;
            Predictions = predictions;
        }

        public string Nickname { get; }

        public IEnumerable<PredictionWriteDto> Predictions { get; }

    }
}
