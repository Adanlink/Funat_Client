using System;
using Assets.Scripts.IoC;
using Autofac;
using EntityController.Entity.Interfaces;
using Server.SharedThings.Packets.ClientPackets.Enums;
using Server.SharedThings.Packets.ClientPackets.Game;
using TMPro;
using UnityEngine;

namespace EntityController.Entity
{
    public class OtherPlayerController : MonoBehaviour, IOtherPlayerController
    {
        public TMP_Text usernameText;
        
        public IPlayer Player { get; set; }

        private bool _remove;

        private void Update()
        {
            usernameText.SetText(Player.Nickname);
            gameObject.transform.SetPosition(Player.X, Player.Y);

            if (_remove)
            {
                _remove = false;
                Destroy(gameObject);
            }
        }

        public void SetPosition(float x, float y)
        {
            Player.X = x;
            Player.Y = y;
        }

        public void Remove()
        {
            _remove = true;
        }
    }
}