using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UserInterface.GameInterface;
using UserInterface.GameMenu;

namespace Assets.Scripts.UserInterface.GameInterface
{
    public class ChatHandler : IChatHandler
    {
        public bool Writing
        {
            get
            {
                return TemporalSaveChat != null ? TemporalSaveChat.Writing : false;
            }
        }

        private HudController HudController;

        private ChatController TemporalSaveChat;

        private bool DestroyChat = false;

        private bool CreateChat = false;

        public ChatHandler(HudController hudController)
        {
            HudController = hudController;
        }

        public void Update()
        {
            if (DestroyChat)
            {
                DestroyChat = false;
                if (TemporalSaveChat == null)
                {
                    return;
                }
                UnityEngine.Object.Destroy(TemporalSaveChat);
            }

            if (CreateChat)
            {
                CreateChat = false;
                if (TemporalSaveChat != null)
                {
                    return;
                }
                TemporalSaveChat = UnityEngine.Object.Instantiate(HudController.Chat, HudController.ToPutHudThing);
            }
        }

        public void EnableChat()
        {
            CreateChat = true;
        }

        public void RemoveThisHud()
        {
            DestroyChat = true;
        }

        public void RecieveMessage(string Message)
        {
            TemporalSaveChat.AddChatMessage(Message);
        }
    }
}
