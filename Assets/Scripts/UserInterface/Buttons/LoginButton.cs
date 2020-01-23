using System;
using System.Threading;
using Assets;
using Assets.Scripts.IoC;
using Autofac;
using Crypto;
using Networking.Serializers;
using Server.SharedThings.Packets.ClientPackets;
using TMPro;
using UnityEngine;

namespace UserInterface.Buttons
{
    public class LoginButton : MonoBehaviour
    {
        public TMP_InputField username;

        public TMP_InputField password;

        public string ip = "127.0.0.1";

        public int port = 27450;

        public void TryToLogin()
        {
            var networkController = UsefulContainer.Instance.Resolve<GameController>().NetworkController;
            if (networkController == null)
            {
                return;
            }
            var thread = new Thread(() =>
            {
                try
                {
                    networkController.Connect(ip, port);
                    networkController.Username = username.text;
                    networkController.SendPacket(new LoginRequest
                    {
                        GameVersion = 0,
                        Username = username.text,
                        PasswordHash = Argon2Hasher.HashPassword(password.text, username.text)
                    });
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            })
            {
                IsBackground = true
            };
            thread.Start();
        }
    }
}
