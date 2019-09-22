using Domain.PointSystems;
using Domain.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.Models
{
    public class LeagueTableLine
    {
        public int Games { get; set; } = 0;

        public int Wins { get; set; } = 0;
        public int Draws { get; set; } = 0;
        public int Loses { get; set; } = 0;

        public int ScoredGoals { get; set; } = 0;
        public int ConcededGoals { get; set; } = 0;

        public int Points { get; set; } = 0;
    }
}