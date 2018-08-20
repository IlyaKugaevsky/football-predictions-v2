using System;
using System.Collections.Generic;
using System.Text;
using WriteModel.Features.Predictions.Dtos;

namespace WriteModel.Features.Teams.Dtos
{
    public class ExpertPredictionsWriteDto
    {
        public ExpertPredictionsWriteDto(int expertId, IEnumerable<PredictionWriteDto> predictions)
        {
            ExpertId = expertId;
            Predictions = predictions;
        }

        public int ExpertId { get; }

        public IEnumerable<PredictionWriteDto> Predictions { get; }

    }
}
