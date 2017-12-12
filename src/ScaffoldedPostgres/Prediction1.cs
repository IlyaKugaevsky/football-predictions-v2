using System;
using System.Collections.Generic;

namespace Persistence {
    public partial class Prediction1 {
        public int Predictionid { get; set; }
        public string Value { get; set; }
        public bool Outcome { get; set; }
        public bool Difference { get; set; }
        public bool Score { get; set; }
        public int Sum { get; set; }
        public int Expertid { get; set; }
        public int Matchid { get; set; }
        public bool? Isclosed { get; set; }

        public Expert Expert { get; set; }
        public Match Match { get; set; }
    }
}