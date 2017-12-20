namespace Predictions.Domain
{
    public abstract class Entity
    {
        private int _Id;
        public virtual int Id
        {
            get { return _Id; }
            protected set { _Id = value; }
        }
    }
}