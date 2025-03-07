namespace Core.Entities.Concrete
{
    public abstract class Entity<TId>
    {
        public Entity()
        {
            Id = default;
        }

        public Entity(TId id)
        {
            Id = id;
        }

        public virtual TId Id { get; set; }
    }
}