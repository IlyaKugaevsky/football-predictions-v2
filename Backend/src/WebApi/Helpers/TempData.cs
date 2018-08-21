using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WriteModel.Features.Teams.Dtos;

namespace WebApi.Helpers
{
    public class TempData
    {
        private readonly List<ExpertPredictionsWriteDto> _predictions = new List<ExpertPredictionsWriteDto>();

        public List<ExpertPredictionsWriteDto> GetPredictions() => _predictions;

        public void AddPrediction(ExpertPredictionsWriteDto prediction) => _predictions.Add(prediction);
    }
}
