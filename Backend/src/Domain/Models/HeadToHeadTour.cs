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
        private readonly List<HeadToHeadMatch> _matches = new List<HeadToHeadMatch>();
        protected HeadToHeadTour()
        {
        }
        
        [ForeignKey("HeadToHeadTournamentId")]
        public HeadToHeadTournament HeadToHeadTournament { get; private set; }
        public int HeadToHeadTournamentId { get; private set; }
        public int ParentTourId { get; private set; }

        [ForeignKey("ParentTourId")]
        public Tour ParentTour { get; private set; }
        
        public IEnumerable<HeadToHeadMatch> Matches => _matches.AsReadOnly();
        
        public void AddMatches(IEnumerable<HeadToHeadMatch> matches)
        {
            _matches.AddRange(matches);
        }

        public void AddMatch(HeadToHeadMatch match)
        {
            _matches.Add(match);
        }
    }
}
