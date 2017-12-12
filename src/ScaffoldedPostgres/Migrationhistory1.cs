using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Migrationhistory1
    {
        public string Migrationid { get; set; }
        public string Contextkey { get; set; }
        public byte[] Model { get; set; }
        public string Productversion { get; set; }
    }
}