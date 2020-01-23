using System.Threading.Tasks;
using Assets.Scripts.UserInterface.Message;
using Server.SharedThings.Packets.ServerPackets;
using UserInterface.Message;

namespace Networking.Packets.Handlers.LoginRegisterMenu
{
    public class LoginFailedHandler : GenericPacketHandlerAsync<LoginFailed>
    {
        private IMessageController MessageController { get; set; }

        public LoginFailedHandler(IMessageController messageController)
        {
            MessageController = messageController;
        }

        protected override Task Handle(LoginFailed packet)
        {
            MessageController.SendNoIntrusiveMsg(Message: "Login failed " + packet.LoginFailedType);
            return Task.CompletedTask;
        }
    }
}
