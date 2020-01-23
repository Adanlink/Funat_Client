using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UserInterface.Buttons
{
    public class ShowLoginUIButton : MonoBehaviour
    {
        public GameObject LoginUI;

        public string RegisterUITag = "RegisterUI";

        public void ShowLogin()
        {
            Destroy(GameObject.FindGameObjectWithTag(RegisterUITag));
            Instantiate(LoginUI, GameObject.Find("Canvas").transform);
        }
    }
}
