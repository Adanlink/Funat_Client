using System.Threading.Tasks;
using Server.SharedThings.Packets.ClientPackets;
using Server.SharedThings.Packets.ServerPackets;
using Server.SharedThings.Packets.ServerPackets.Enums;

namespace Networking.Packets.Handlers.Game.CharacterSelection
{
    public class CharacterCreateResponseHandler : GenericPacketHandlerAsync<CharacterCreateResponse>
    {
        private readonly GameController _gameController;

        public CharacterCreateResponseHandler(GameController gameController)
        {
            _gameController = gameController;
        }
        
        protected override Task Handle(CharacterCreateResponse packet)
        {
            switch (packet.CharacterCreateResponseType)
            {
                case CharacterCreateResponseType.CharacterCreated:
                    _gameController.NetworkController.SendPacket(new CharacterListRequest());
                    _gameController.HudController.CharacterCreateController.RemoveThisHud();
                    break;
            }
            _gameController.MessageController.SendNoIntrusiveMsg("" + packet.CharacterCreateResponseType);
            return Task.CompletedTask;
        }
    }
}