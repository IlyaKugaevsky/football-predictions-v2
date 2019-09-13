using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    // ReSharper disable UnusedAutoPropertyAccessor.Local
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]

    public class HeadToHeadTour: Entity
    {
        protected HeadToHeadTour()
        {
        }
        public HeadToHeadTournament HeadToHeadTournament { get; private set; }
        public int HeadToHeadTournamentId { get; private set; }

        public int HeadToHeadTourId { get; private set; }


        public int ParentTourId { get; private set; }

        [ForeignKey("ParentTourId")]
        public Tour ParentTour { get; private set; }

        public virtual List<HeadToHeadMatch> Matches { get; private set; }
    }
}
