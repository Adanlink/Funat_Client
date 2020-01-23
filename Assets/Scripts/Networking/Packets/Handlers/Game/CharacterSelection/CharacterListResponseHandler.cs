using System.Threading.Tasks;
using Server.SharedThings.Packets.ServerPackets;

namespace Networking.Packets.Handlers.Game.CharacterSelection
{
    public class CharacterListResponseHandler : GenericPacketHandlerAsync<CharacterListResponse>
    {
        private static GameController _gameController;
        
        public CharacterListResponseHandler(GameController gameController)
        {
            _gameController = gameController;
        }
        
        protected override Task Handle(CharacterListResponse packet)
        {
            _gameController.HudController.CharacterListController.ShowCharacterList(packet.Characters);
            return Task.CompletedTask;
        }
    }
}