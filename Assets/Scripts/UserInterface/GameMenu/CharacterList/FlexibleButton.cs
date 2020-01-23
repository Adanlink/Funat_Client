using System;
using Assets.Scripts.IoC;
using Autofac;
using Networking;
using Server.SharedThings.Packets.ClientPackets;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.GameMenu.CharacterList
{
    public class FlexibleButton : MonoBehaviour
    {
        private FlexibleButtonStatus _function;

        private GameController _gameController;

        public CharacterRepresentationBase CharacterRepresentationBase;

        public Image ImageComponent;

        public void SetFunction(FlexibleButtonStatus flexibleButtonStatus)
        {
            _function = flexibleButtonStatus;
            _gameController = UsefulContainer.Instance.Resolve<GameController>();
            //TODO change flexible button image to play button or anything
            switch (flexibleButtonStatus)
            {
                case FlexibleButtonStatus.Create:
                    ImageComponent.color = Color.blue;
                    break;
                case FlexibleButtonStatus.Delete:
                    ImageComponent.color = Color.red;
                    break;
                case FlexibleButtonStatus.Play:
                    ImageComponent.color = Color.green;
                    break;
            }
        }

        public void ButtonFunction()
        {
            switch (_function)
            {
                case FlexibleButtonStatus.Play:
                    _gameController.NetworkController.SendPacket(new CharacterSelectRequest
                    {
                        Nickname = CharacterRepresentationBase.Character.Nickname
                    });
                    break;
                case FlexibleButtonStatus.Create:
                    _gameController.HudController.CharacterCreateController.ShowCharacterCreate();
                    break;
                case FlexibleButtonStatus.Delete:
                    _gameController.NetworkController.SendPacket(new CharacterDeleteRequest
                    {
                        Nickname = CharacterRepresentationBase.Character.Nickname
                    });
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ToggleDeleteMethod()
        {
            switch (_function)
            {
                case FlexibleButtonStatus.Delete:
                    SetFunction(FlexibleButtonStatus.Play);
                    return;
                case FlexibleButtonStatus.Play:
                    SetFunction(FlexibleButtonStatus.Delete);
                    break;
                case FlexibleButtonStatus.Create:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
