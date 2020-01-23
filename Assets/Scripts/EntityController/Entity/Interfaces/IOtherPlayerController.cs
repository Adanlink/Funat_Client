namespace EntityController.Entity.Interfaces
{
    public interface IOtherPlayerController : IGenericEntityController
    {
        IPlayer Player { get; set; }
    }
}