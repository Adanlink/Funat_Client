using Assets.Scripts.IoC;
using Autofac;
using Server.SharedThings.Packets.ClientPackets;
using UnityEngine;

namespace Networking
{
    public class NetworkInitializer : MonoBehaviour
    {
        public string ip = "127.0.0.1";

        public int port = 27451;
        
        void Start()
        {
            var networkController = UsefulContainer.Instance.Resolve<GameController>().NetworkController;
            networkController?.Connect(ip, port);
            networkController?.SendPacket(new SessionLoginRequest
            {
                GameVersion = 0,
                SessionId = networkController.SessionId,
                Username = networkController.Username
            });
            Destroy(gameObject);
        }
    }
}
