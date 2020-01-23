using System;
using System.Threading;
using Assets;
using Assets.Scripts.IoC;
using Autofac;
using Crypto;
using Server.SharedThings.Packets.ClientPackets;
using TMPro;
using UnityEngine;

namespace UserInterface.Buttons
{
    public class RegisterButton : MonoBehaviour
    {
        public TMP_InputField Key;

        public TMP_InputField Username;

        public TMP_InputField Password;

        public TMP_InputField ConfirmPassword;

        public string Ip = "127.0.0.1";

        public int Port = 27450;

        public void TryToRegister()
        {
            if (Password.text != ConfirmPassword.text)
            {
                UsefulContainer.Instance.Resolve<GameController>()
                    .MessageController.SendNoIntrusiveMsg("The provided passwords do not match.");
                return;
            }
            var networkController = UsefulContainer.Instance.Resolve<GameController>().NetworkController;
            var thread = new Thread(() =>
            {
                try
                {
                    networkController.Connect(Ip, Port);

                    networkController.SendPacket(new RegisterRequest()
                    {
                        Key = Key.text,
                        Username = Username.text,
                        PasswordHash = Argon2Hasher.HashPassword(Password.text, Username.text)
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
