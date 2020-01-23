using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using System;

namespace Assets.Scripts.UserInterface.Message
{
    public class MessageHandler : MonoBehaviour
    {
        private bool ShouldDestroy { get; set; }

        void Update()
        {
            if (ShouldDestroy)
            {
                var asd = GetComponent<TextMeshProUGUI>();
                asd.color = new Color(asd.color.r, asd.color.g, asd.color.b, asd.color.a - (Time.deltaTime * 0.5f));
                if (asd.color.a <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }

        public void StartMessage(string Message)
        {
            GetComponent<TextMeshProUGUI>().text = Message;
            new Thread(() =>
            {
                Thread.Sleep(((Message.Length/8) + 2)*1000);
                ShouldDestroy = true;
            })
            {
                IsBackground = true
            }.Start();
        }
    }
}