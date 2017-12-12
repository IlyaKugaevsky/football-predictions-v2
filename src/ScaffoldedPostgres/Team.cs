using System;
using System.Collections.Generic;

namespace Persistence {
    public partial class Team {
        public Team () {
            MatchAwayteam = new HashSet<Match> ();
            MatchHometeam = new HashSet<Match> ();
        }

        public int Teamid { get; set; }
        public string Title { get; set; }

        public ICollection<Match> MatchAwayteam { get; set; }
        public ICollection<Match> MatchHometeam { get; set; }
    }
}