using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Expert
    {
        public Expert()
        {
            Prediction1 = new HashSet<Prediction1>();
        }

        public int Expertid { get; set; }
        public string Nickname { get; set; }
        public int Outcomes { get; set; }
        public int Differences { get; set; }
        public int Scores { get; set; }
        public int Sum { get; set; }

        public ICollection<Prediction1> Prediction1 { get; set; }
    }
}