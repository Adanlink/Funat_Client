using Assets.Scripts.IoC;
using Autofac;
using Networking;
using Server.SharedThings.Packets.ClientPackets;
using TMPro;
using UnityEngine;

namespace UserInterface.GameMenu.CreateCharacter
{
    public class CreateButton : MonoBehaviour
    {
        public TMP_InputField nickname;

        private INetworkController NetworkController;
        
        public void CreateCharacter()
        {
            //TODO to improve
            NetworkController = UsefulContainer.Instance.Resolve<GameController>().NetworkController;
            NetworkController.SendPacket(new CharacterCreateRequest
            {
                Nickname = nickname.text
            });
        }
    }
}
