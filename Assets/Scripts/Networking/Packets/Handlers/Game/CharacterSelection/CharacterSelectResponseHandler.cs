using System;
using System.Threading.Tasks;
using Server.SharedThings.Packets.ServerPackets;
using Server.SharedThings.Packets.ServerPackets.Enums;

namespace Networking.Packets.Handlers.Game.CharacterSelection
{
    public class CharacterSelectResponseHandler : GenericPacketHandlerAsync<CharacterSelectResponse>
    {
        private readonly GameController _gameController;

        public CharacterSelectResponseHandler(GameController gameController)
        {
            _gameController = gameController;
        }
        
        protected override Task Handle(CharacterSelectResponse packet)
        {
            switch (packet.CharacterSelectResponseType)
            {
                case CharacterSelectResponseType.CharacterSelected:
                    _gameController.HudController.CharacterCreateController.RemoveThisHud();
                    _gameController.HudController.CharacterListController.RemoveThisHud();
                    break;
                case CharacterSelectResponseType.CharacterAlreadyPlaying:
                    break;
                case CharacterSelectResponseType.CouldNotFindCharacter:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            _gameController.MessageController.SendNoIntrusiveMsg("" + packet.CharacterSelectResponseType);
            return Task.CompletedTask;
        }
    }
}