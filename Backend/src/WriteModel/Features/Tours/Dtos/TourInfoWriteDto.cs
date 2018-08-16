using System;

namespace WriteModel.Features.Tours.Dtos
{
    public class TourInfoWriteDto
    {
        public TourInfoWriteDto(int number, DateTime startDate, DateTime endDate)
        {
            Number = number;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int Number { get;  }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}
