using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UserInterface.Message;

namespace Assets.Scripts.UserInterface.Message
{
    public class MessageController : MonoBehaviour, IMessageController
    {
        public GameObject NoIntrusiveMsg;

        //private Transform _Transform;

        private readonly Queue<Tuple<GameObject, string>> Messages = new Queue<Tuple<GameObject, string>>();

        // Start is called before the first frame update
        /*void Start()
        {
        }*/

        private void Update()
        {
            if (Messages?.Count == 0)
            {
                return;
            }

            Transform target;

            try
            {
                target = GameObject.FindGameObjectWithTag("ForMessages").GetComponent<Transform>();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return;
            }

            if (target != null)
            {
                var asd = Messages.Dequeue();

                Instantiate(asd.Item1, target).GetComponent<MessageHandler>().StartMessage(asd.Item2);
            }
        }

        public void SendNoIntrusiveMsg(string Message)
        {
            Messages?.Enqueue(new Tuple<GameObject, string>(
                NoIntrusiveMsg, Message));
        }
    }
}