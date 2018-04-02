namespace Domain
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        public override int GetHashCode() => Id;

        public override bool Equals(object obj)
        {
            Entity other = obj as Entity;
            if (obj == null) return false;

            return (this.Id == other.Id) && (this.GetType() == other.GetType());
        }
    }
}