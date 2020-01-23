using System;
using System.Threading.Tasks;
using Server.SharedThings.Packets.ServerPackets;
using Server.SharedThings.Packets.ServerPackets.Enums;
using Server.SharedThings.Packets.ServerPackets.Game;

namespace Networking.Packets.Handlers.Game
{
    public class EntityUpdatePositionHandler : GenericPacketHandlerAsync<EntityUpdatePosition>
    {
        private readonly GameController _gameController;

        public EntityUpdatePositionHandler(GameController gameController)
        {
            _gameController = gameController;
        }
        
        protected override Task Handle(EntityUpdatePosition packet)
        {
            if (_gameController.EntitiesController.Entities.TryGetValue(Guid.Parse(packet.Id), out var entity))
            {
                entity.SetPosition(packet.X, packet.Y);
            }
            return Task.CompletedTask;
        }
    }
}