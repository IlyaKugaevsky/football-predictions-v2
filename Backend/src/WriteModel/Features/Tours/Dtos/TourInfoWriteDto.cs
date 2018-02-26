using System;
using System.Collections.Generic;
using System.Text;

namespace WriteModel.Features.Tours.Dtos
{
    public class TourInfoWriteDto
    {
        TourInfoWriteDto(int tourNumber, DateTime startDate, DateTime endDate)
        {
            TourNumber = tourNumber;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int TourNumber { get;  }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}
