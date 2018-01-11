namespace Domain.Models
{
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