using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Models
{
    // ReSharper disable UnusedAutoPropertyAccessor.Local
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class HeadToHeadTournament: Entity
    {
        private readonly List<HeadToHeadTour> _tours = new List<HeadToHeadTour>();
        protected HeadToHeadTournament()
        {
        }

        public HeadToHeadTournament(int parentTournamentId)
        {
            ParentTournamentId = parentTournamentId;
        }

        public int ParentTournamentId { get; private set; }
        
        [ForeignKey("ParentTournamentId")]
        public Tournament ParentTournament { get; private set; }
        
        public IEnumerable<HeadToHeadTour> Tours => _tours.AsReadOnly();
        
        public void AddTours(IEnumerable<HeadToHeadTour> tours)
        {
            _tours.AddRange(tours);
        }

        public void AddTour(HeadToHeadTour tour)
        {
            _tours.Add(tour);
        }
    }
}
