using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Tournament1
    {
        public Tournament1 ()
        {
            Tour1 = new HashSet<Tour1> ();
        }

        public int Tournamentid { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string Title { get; set; }

        public ICollection<Tour1> Tour1 { get; set; }
    }
}