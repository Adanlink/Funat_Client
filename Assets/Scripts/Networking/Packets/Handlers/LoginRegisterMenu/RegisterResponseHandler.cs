using System.Threading.Tasks;
using Assets.Scripts.UserInterface.Message;
using Server.SharedThings.Packets.ServerPackets;
using UserInterface.Message;

namespace Networking.Packets.Handlers.LoginRegisterMenu
{
    public class RegisterResponseHandler : GenericPacketHandlerAsync<RegisterResponse>
    {
        private IMessageController MessageController { get; set; }

        public RegisterResponseHandler(IMessageController messageController)
        {
            MessageController = messageController;
        }

        protected override Task Handle(RegisterResponse packet)
        {
            MessageController.SendNoIntrusiveMsg("Register response " + packet.RegisterResponseType);
            return Task.CompletedTask;
        }
    }
}
