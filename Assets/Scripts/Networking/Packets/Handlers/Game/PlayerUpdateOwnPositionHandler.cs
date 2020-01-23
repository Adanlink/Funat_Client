using System;
using System.Threading.Tasks;
using Server.SharedThings.Packets.ServerPackets;
using Server.SharedThings.Packets.ServerPackets.Enums;
using Server.SharedThings.Packets.ServerPackets.Game;

namespace Networking.Packets.Handlers.Game
{
    public class PlayerUpdateOwnPositionHandler : GenericPacketHandlerAsync<PlayerUpdateOwnPosition>
    {
        private readonly GameController _gameController;

        public PlayerUpdateOwnPositionHandler(GameController gameController)
        {
            _gameController = gameController;
        }
        
        protected override Task Handle(PlayerUpdateOwnPosition packet)
        {
            _gameController.EntitiesController.OwnPlayerController.SetPosition(packet.X, packet.Y);
            return Task.CompletedTask;
        }
    }
}