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
    public class OwnPlayerController : MonoBehaviour, IOwnPlayerController
    {
        public TMP_Text usernameText;
        
        public IOwnPlayer OwnPlayer { get; set; }

        public Transform Transform => transform;

        public CameraPlayerController OwnCamera { get; set; } = null;
        
        private GameController _gameController;

        private MovementDirection _lastMovementDirection = MovementDirection.Null;

        private void Awake()
        {
            _gameController = UsefulContainer.Instance.Resolve<GameController>();
            /*if (_gameController.EntitiesController.OwnPlayerController != null)
            {
                Destroy(gameObject);
                return;
            }*/
            _gameController.HudController.ChatController.EnableChat();
        }

        private void Update()
        {
            usernameText.SetText(OwnPlayer.Nickname);
            UpdatePosition();
            SendMovementDirection();
        }

        private void UpdatePosition()
        {
            transform.SetPosition(OwnPlayer.X, OwnPlayer.Y);
            if (OwnCamera != null)
            {
                OwnCamera.UpdatePosition(OwnPlayer.X, OwnPlayer.Y);
            }
        }
        
        private void SendMovementDirection()
        {
            if (_gameController.HudController.ChatController.Writing)
            {
                return;
            }
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.D))
                {
                    SendMovement(MovementDirection.RightUp);
                    return;
                }

                if (Input.GetKey(KeyCode.A))
                {
                    SendMovement(MovementDirection.LeftUp);
                    return;
                }
                
                SendMovement(MovementDirection.Up);
                return;
            }
            
            if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.D))
                {
                    SendMovement(MovementDirection.RightDown);
                    return;
                }

                if (Input.GetKey(KeyCode.A))
                {
                    SendMovement(MovementDirection.LeftDown);
                    return;
                }
                
                SendMovement(MovementDirection.Down);
                return;
            }

            if (Input.GetKey(KeyCode.A))
            {
                SendMovement(MovementDirection.Left);
                return;
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                SendMovement(MovementDirection.Right);
                return;
            }

            SendMovement(MovementDirection.Null);
        }

        private void SendMovement(MovementDirection movementDirection)
        {
            if (movementDirection == _lastMovementDirection)
            {
                return;
            }

            _gameController.NetworkController.SendPacket(new ClientDeclareMovementDirection
            {
                MovementDirection = movementDirection
            });

            _lastMovementDirection = movementDirection;
        }

        public void SetPosition(float x, float y)
        {
            OwnPlayer.X = x;
            OwnPlayer.Y = y;
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}