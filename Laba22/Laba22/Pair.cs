namespace Laba22
{
    public sealed class Pair<TIdType, TEntityType> 
    {
        public Pair(TIdType id, TEntityType entity)
        {
            Id = id;
            Entity = entity;
        }

        public TIdType Id { get; }
        public TEntityType Entity { get; }
    }
}