using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UserInterface.Buttons
{
    public class ExitButton : MonoBehaviour
    {
        public void Exit()
        {
            Application.Quit();
        }
    }
}