using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Match
    {
        public Match()
        {
            Prediction1 = new HashSet<Prediction1>();
        }

        public int Matchid { get; set; }
        public string Title { get; set; }
        public string Score { get; set; }
        public DateTime Date { get; set; }
        public int Awayteamid { get; set; }
        public int Hometeamid { get; set; }
        public int Tourid { get; set; }

        public Team Awayteam { get; set; }
        public Team Hometeam { get; set; }
        public Tour1 Tour { get; set; }
        public ICollection<Prediction1> Prediction1 { get; set; }
    }
}
