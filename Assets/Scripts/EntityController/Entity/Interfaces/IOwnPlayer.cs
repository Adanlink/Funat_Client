using System.Collections;

namespace EntityController.Entity.Interfaces
{
    public interface IOwnPlayer : IEntity
    {
        string Nickname { get; set; }
    }
}