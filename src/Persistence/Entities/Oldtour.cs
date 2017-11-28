using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Oldtour
    {
        public int Oldtourid { get; set; }
        public int Oldtournumber { get; set; }
        public bool Isclosed { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
    }
}
