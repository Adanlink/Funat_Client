using System;
using System.Threading.Tasks;
using Assets.Scripts.IoC;
using Autofac;
using Server.SharedThings.Packets.ClientPackets;
using Server.SharedThings.Packets.ServerPackets;
using Server.SharedThings.Packets.ServerPackets.Enums;
using UserInterface.Message;

namespace Networking.Packets.Handlers.Game
{
    public class SessionLoginResponseHandler : GenericPacketHandlerAsync<SessionLoginResponse>
    {
        private static readonly GameController
            GameController = UsefulContainer.Instance.Resolve<GameController>();
        
        protected override Task Handle(SessionLoginResponse packet)
        {
            switch (packet.SessionLoginResponseType)
            {
                case SessionLoginResponseType.FailedLogin:
                case SessionLoginResponseType.MaxConnectionsReached:
                    GameController.SceneController.LoadScene("Main");
                    break;
                case SessionLoginResponseType.SuccessfulLogin:
                    GameController.NetworkController.SendPacket(new CharacterListRequest());
                    //GameController.NetworkController.SendPacket(new SessionLoginRequest());
                    break;
                case SessionLoginResponseType.AlreadyLoggedIn:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            GameController.MessageController.SendNoIntrusiveMsg("" + packet.SessionLoginResponseType);
            return Task.CompletedTask;
        }
    }
}