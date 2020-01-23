using System;
using System.Threading.Tasks;
using Server.SharedThings.Packets.ServerPackets;
using Server.SharedThings.Packets.ServerPackets.Enums;
using Server.SharedThings.Packets.ServerPackets.Game;

namespace Networking.Packets.Handlers.Game
{
    public class RevokeEntityHandler : GenericPacketHandlerAsync<RevokeEntity>
    {
        private readonly GameController _gameController;

        public RevokeEntityHandler(GameController gameController)
        {
            _gameController = gameController;
        }

        protected override Task Handle(RevokeEntity packet)
        {
            _gameController.EntitiesController.RemoveEntity(Guid.Parse(packet.Id));
            return Task.CompletedTask;
        }
    }
}