namespace EntityController.Entity.Interfaces
{
    public interface IEntityController : IGenericEntityController
    {
        IEntity Entity { get; set; }
    }
}