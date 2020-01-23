using System;

namespace EntityController.Entity.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
        
        float X { get; set; }
        
        float Y { get; set; }
    }
}