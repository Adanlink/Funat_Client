using System;
using System.Threading.Tasks;
using Server.SharedThings.Packets.ServerPackets;
using Server.SharedThings.Packets.ServerPackets.Enums;
using Server.SharedThings.Packets.ServerPackets.Game;
using UnityEngine;

namespace Networking.Packets.Handlers.Game
{
    public class DeclareEntityHandler : GenericPacketHandlerAsync<DeclareEntity>
    {
        private readonly GameController _gameController;

        public DeclareEntityHandler(GameController gameController)
        {
            _gameController = gameController;
        }
        
        protected override Task Handle(DeclareEntity packet)
        {
            _gameController.EntitiesController.AddNewEntity(packet.EntityBase);
            Debug.Log("LaWea2.0");
            return Task.CompletedTask;
        }
    }
}