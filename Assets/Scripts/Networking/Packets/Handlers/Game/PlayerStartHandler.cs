using System;
using System.Threading.Tasks;
using Server.SharedThings.Packets.ServerPackets;
using Server.SharedThings.Packets.ServerPackets.Enums;
using Server.SharedThings.Packets.ServerPackets.Game;
using UnityEngine;

namespace Networking.Packets.Handlers.Game
{
    public class PlayerStartHandler : GenericPacketHandlerAsync<PlayerStart>
    {
        private readonly GameController _gameController;

        public PlayerStartHandler(GameController gameController)
        {
            _gameController = gameController;
        }
        
        protected override Task Handle(PlayerStart packet)
        {
            _gameController.EntitiesController.StartOwnPlayer(packet.OwnPlayer);
            return Task.CompletedTask;
        }
    }
}