using System.Collections.Generic;

namespace Domain.Models
{
    public class Expert : Entity
    {
        private readonly List<Prediction> _predictions
            = new List<Prediction>();

        public string Nickname { get; private set; }

        public IEnumerable<Prediction> Predictions => _predictions.AsReadOnly();
    }
}