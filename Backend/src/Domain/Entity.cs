// ReSharper disable ArrangeThisQualifier
namespace Domain
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        // ReSharper disable once NonReadonlyMemberInGetHashCode
        public override int GetHashCode() => Id;

        public override bool Equals(object obj)
        {

            if (obj is Entity other)
            {
                return (this.Id == other.Id) && (this.GetType() == other.GetType());
            }
            else
            {
                return false;
            }
        }
    }
}