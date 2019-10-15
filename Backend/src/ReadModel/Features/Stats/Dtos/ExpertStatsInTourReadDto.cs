using System.Collections.Generic;

namespace ReadModel.Features.Stats.Dtos
{
    public class ExpertStatsInTourReadDto
    {
        public int TourNumber { get;}
        public IEnumerable<ExpertStatsReadDto>  ExpertStatsInTour { get; }

        public ExpertStatsInTourReadDto(int tourNumber,  IEnumerable<ExpertStatsReadDto> expertStatsInTour)
        {
            TourNumber = tourNumber;
            ExpertStatsInTour = expertStatsInTour;
        }
    }
}