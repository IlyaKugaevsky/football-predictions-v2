using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Tour1
    {
        public Tour1()
        {
            Match = new HashSet<Match>();
        }

        public int Tourid { get; set; }
        public int Tournamentid { get; set; }
        public int Tournumber { get; set; }
        public bool Isclosed { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }

        public Tournament1 Tournament { get; set; }
        public ICollection<Match> Match { get; set; }
    }
}
