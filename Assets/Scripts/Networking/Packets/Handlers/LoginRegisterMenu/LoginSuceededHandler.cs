using System.Threading.Tasks;
using Server.SharedThings.Packets.ServerPackets;

namespace Networking.Packets.Handlers.LoginRegisterMenu
{
    public class LoginSucceededHandler : GenericPacketHandlerAsync<LoginSucceeded>
    {
        private readonly GameController _gameController;
        
        public LoginSucceededHandler(GameController gameController)
        {
            _gameController = gameController;
        }

        protected override Task Handle(LoginSucceeded packet)
        {
            _gameController.MessageController.SendNoIntrusiveMsg("Login succeeded!");
            _gameController.NetworkController.SessionId = packet.SessionId;
            _gameController.SceneController.LoadScene("Game");
            return Task.CompletedTask;
        }
    }
}
