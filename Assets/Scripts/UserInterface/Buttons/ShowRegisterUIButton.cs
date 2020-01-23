using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UserInterface.Buttons
{
    public class ShowRegisterUIButton : MonoBehaviour
    {
        public GameObject RegisterUI;

        public string LoginUITag = "LoginUI";

        public void ShowRegister()
        {
            Destroy(GameObject.FindGameObjectWithTag(LoginUITag));
            Instantiate(RegisterUI, GameObject.Find("Canvas").transform);
        }
    }
}
