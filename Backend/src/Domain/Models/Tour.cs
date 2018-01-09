using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Predictions.Domain.Models
{
    public class Tour: Entity
    {
        private readonly List<Match> _matches = new List<Match>(); 
        protected Tour() { }
        public Tour (int number, DateTime startDate, DateTime endDate)
        {
            Number = number;
            StartDate = startDate;
            EndDate = endDate;
        }
        internal Tour (int id, int number, DateTime startDate, DateTime endDate)
            :this(number, startDate, endDate)
        {
            Id = id;
        }

        public Tournament Tournament { get; private set; }
        public int TournamentId { get; private set; }

        public int Number { get; private set; }
        public bool IsClosed { get; private set; } = false;
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public IEnumerable<Match> Matches => _matches.AsReadOnly();

        public void AttachToTournament(int tournamentId)
        {
            TournamentId = tournamentId;
        }

        public void Close() 
        {
            if (IsClosed) 
            {
                throw new InvalidOperationException("The tour is already closed.");
            }
            IsClosed = true;
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}