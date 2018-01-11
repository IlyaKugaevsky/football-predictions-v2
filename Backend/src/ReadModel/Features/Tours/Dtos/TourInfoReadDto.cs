using System;

namespace ReadModel.Features.Tours.Dtos
{
    public class TourInfoReadDto
    {
        public int Id { get; private set; }
        public int Number { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsClosed { get; private set; }
    }
}