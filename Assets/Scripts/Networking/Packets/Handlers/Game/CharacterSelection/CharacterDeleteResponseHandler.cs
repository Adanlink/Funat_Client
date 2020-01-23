using System.Threading.Tasks;
using Server.SharedThings.Packets.ClientPackets;
using Server.SharedThings.Packets.ServerPackets;
using Server.SharedThings.Packets.ServerPackets.Enums;

namespace Networking.Packets.Handlers.Game.CharacterSelection
{
    public class CharacterDeleteResponseHandler : GenericPacketHandlerAsync<CharacterDeleteResponse>
    {
        private readonly GameController _gameController;

        public CharacterDeleteResponseHandler(GameController gameController)
        {
            _gameController = gameController;
        }
        
        protected override Task Handle(CharacterDeleteResponse packet)
        {
            switch (packet.CharacterDeleteResponseType)
            {
                case CharacterDeleteResponseType.CharacterDeleted:
                    _gameController.NetworkController.SendPacket(new CharacterListRequest());
                    break;
            }
            _gameController.MessageController.SendNoIntrusiveMsg("" + packet.CharacterDeleteResponseType);
            return Task.CompletedTask;
        }
    }
}