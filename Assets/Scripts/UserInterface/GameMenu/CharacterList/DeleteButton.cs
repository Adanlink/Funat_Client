using Assets.Scripts.IoC;
using Autofac;
using UnityEngine;

namespace UserInterface.GameMenu.CharacterList
{
    public class DeleteButton : MonoBehaviour
    {
        public void ButtonFunction()
        {
            UsefulContainer.Instance.Resolve<GameController>().HudController.CharacterListController.ToggleDeleteMode();
        }
    }
}