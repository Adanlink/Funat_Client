using System;
using System.Threading;
using Assets;
using Assets.Scripts.IoC;
using Autofac;
using Crypto;
using Server.SharedThings.Packets.ClientPackets;
using TMPro;
using UnityEngine;
using Object = System.Object;

namespace UserInterface.Buttons
{
    public class BackButton : MonoBehaviour
    {
        public GameObject ObjectToDelete;

        public void ButtonFunction()
        {
            Destroy(ObjectToDelete);
        }
    }
}
