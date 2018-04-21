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

        public int Id { get; }
        public int Number { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public bool IsClosed { get; }
    }
}