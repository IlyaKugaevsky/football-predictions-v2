using System;
using System.Collections.Generic;
using System.Text;
using Domain.PointSystems;
using Domain.PredictionEvalSystems;

namespace Domain.PredictionEvalSystems
{
    public class ThreePointSystem: IPointSystem
    {
        public int OutcomeWeight => 1;
        public int DifferenceWeight => 2;
        public int ScoreWeight => 3;
    }
}
