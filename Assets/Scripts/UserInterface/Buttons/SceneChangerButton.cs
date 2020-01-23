using Assets.Scripts.IoC;
using Autofac;
using UnityEngine;

namespace UserInterface.Buttons
{
    public class SceneChangerButton : MonoBehaviour
    {
        public string SceneToGo;
        public void ButtonFunction()
        {
            UsefulContainer.Instance.Resolve<GameController>().SceneController.LoadScene(SceneToGo);
        }
    }
}