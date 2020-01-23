using UserInterface.GameInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.IoC;
using Autofac;
using Server.SharedThings.Packets.ClientPackets.Game;
using System;

namespace UserInterface.GameInterface
{
    public class ChatController : MonoBehaviour, IChatController
    {
        public ScrollRect ChatMessagesScrollRect;

        public TMP_Text ChatMessageTemplate;

        public TMP_InputField ChatInput;

        public bool Writing { get; private set; } = false;

        private static GameController GameController;

        private readonly Queue<TMP_Text> ChatMessages = new Queue<TMP_Text>();

        private readonly Queue<string> NewChatMessages = new Queue<string>();

        private void Update()
        {
            GameController = UsefulContainer.Instance.Resolve<GameController>();
            if (GameController == default)
            {
                return;
            }
            UpdateChat();
            PullNewChatMessages();
        }

        private void UpdateChat()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (Writing)
                {
                    Debug.Log("Works2");
                    ChatInput.DeactivateInputField();
                    var text = ChatInput.text;
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        GameController.NetworkController.SendPacketAsync(new ClientSendChatMessage
                        {
                            Message = text,
                        });
                        AddChatMessage($"<{GameController.EntitiesController.OwnPlayerController.OwnPlayer.Nickname}> " + text);
                    }
                    ChatInput.SetTextWithoutNotify("");
                    Writing = false;
                }
                else
                {
                    Debug.Log("Works");
                    ChatInput.ActivateInputField();
                    Writing = true;
                }
            }
        }

        private void PullNewChatMessages()
        {
            if (NewChatMessages.Count < 1)
            {
                return;
            }

            var newMessage = Instantiate(ChatMessageTemplate, ChatMessagesScrollRect.content);
            var timeNow = DateTime.Now;
            newMessage.SetText(
                "[<#FFFF80>" + timeNow.Hour.ToString("d2") + ":" + timeNow.Minute.ToString("d2") + ":" + timeNow.Second.ToString("d2") + "</color>] "
                + NewChatMessages.Dequeue());

            ChatMessages.Enqueue(newMessage);
            if (ChatMessages.Count > 100)
            {
                Destroy(ChatMessages.Dequeue().gameObject);
            }

            ChatMessagesScrollRect.verticalScrollbar.SetValueWithoutNotify(0);
        }

        public void AddChatMessage(string Message)
        {
            if (string.IsNullOrWhiteSpace(Message))
            {
                return;
            }
            NewChatMessages.Enqueue(Message);
        }
    }
}
