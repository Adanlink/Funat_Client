using System;
using System.Collections.Generic;
using EntityController.Entity.Interfaces;
using Server.SharedThings.Packets.Representations;

namespace EntityController
{
    public interface IEntitiesController
    {
        IDictionary<Guid, IGenericEntityController> Entities { get; set; }

        IOwnPlayerController OwnPlayerController { get; set; }

        void AddNewEntity(Player player);

        void RemoveEntity(Guid guid);

        void StartOwnPlayer(OwnPlayer player);
    }
}