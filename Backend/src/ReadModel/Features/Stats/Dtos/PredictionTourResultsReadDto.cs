using System;
using System.Collections.Generic;
using System.Text;
using ReadModel.Features.Experts.Dtos;

namespace ReadModel.Features.Stats.Dtos
{
    class PredictionTourResultsReadDto
    {
        public int TourNumber { get; }
        IEnumerable<ExpertTourResultsReadDto> ExpertResults { get; }
    }
}
