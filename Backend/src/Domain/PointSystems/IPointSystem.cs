using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.PointSystems
{
    public interface IPointSystem
    {
        int OutcomeWeight { get; }
        int DifferenceWeight { get; }
        int ScoreWeight { get; }
    }
}
