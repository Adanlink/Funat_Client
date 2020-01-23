using System.Collections;

namespace EntityController.Entity.Interfaces
{
    public interface IPlayer : IEntity
    {
        string Nickname { get; set; }
    }
}