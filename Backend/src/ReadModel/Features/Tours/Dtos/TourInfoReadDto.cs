using System;

namespace ReadModel.Features.Tours.Dtos
{
    public class TourInfoReadDto
    {
        public TourInfoReadDto(int id, int number, DateTime startDate, DateTime endDate, bool isClosed)
        {
            Id = id;
            Number = number;
            StartDate = startDate;
            EndDate = endDate;
            IsClosed = isClosed;
        }

        public int Id { get; private set; }
        public int Number { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsClosed { get; private set; }
    }
}