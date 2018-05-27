using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.PointSystems
{
    public class LowDrawPlayoffPointSystem: IExtraTimePointSystem, ICommonPointSystem
    {
        public int OutcomeWeight => 1;
        public int DrawDIfferenceWeight => 1;
        public int DifferenceWeight => 2;
        public int ScoreWeight => 3;
        public int MatchWinnerWeight => 1;
    }
}
