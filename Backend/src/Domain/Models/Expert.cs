using System.Collections.Generic;

namespace Domain.Models
{
    public class Expert : Entity
    {
        private readonly List<Prediction> _predictions
            = new List<Prediction>();

        protected Expert()
        { }

        public Expert(string nickname)
        {
            Nickname = nickname;
        }

        internal Expert(int expertId, string nickname)
        {
            Id = expertId;
            Nickname = nickname;
        }

        public string Nickname { get; private set; }

        public IEnumerable<Prediction> Predictions => _predictions.AsReadOnly();
    }
}