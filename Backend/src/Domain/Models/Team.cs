using System.Diagnostics.CodeAnalysis;

namespace Domain.Models
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class Team : Entity
    {
        protected Team() {}

        public Team(string title)
        {
            Title = title;
        }

        internal Team(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public string Title { get; private set; }
    }
}