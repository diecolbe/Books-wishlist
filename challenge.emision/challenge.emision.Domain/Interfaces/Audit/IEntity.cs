namespace challenge.emision.domain.Interfaces.Audit
{
    public interface IEntity<TId> : IEntity
    {
        TId Id { get; set; }
    }

    public interface IEntity
    {

    }
}
