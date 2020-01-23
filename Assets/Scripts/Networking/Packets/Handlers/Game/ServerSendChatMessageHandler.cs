using System;
using System.Threading.Tasks;
using Server.SharedThings.Packets.ServerPackets;
using Server.SharedThings.Packets.ServerPackets.Enums;
using Server.SharedThings.Packets.ServerPackets.Game;
using UnityEngine;

namespace Networking.Packets.Handlers.Game
{
    public class ServerSendChatMessageHandler : GenericPacketHandlerAsync<ServerSendChatMessage>
    {
        private readonly GameController _gameController;

        public ServerSendChatMessageHandler(GameController gameController)
        {
            _gameController = gameController;
        }

        protected override Task Handle(ServerSendChatMessage packet)
        {
            _gameController.HudController.ChatController.RecieveMessage(packet.Message);
            return Task.CompletedTask;
        }
    }
}