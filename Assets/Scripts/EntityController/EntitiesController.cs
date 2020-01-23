using System;
using System.Collections.Generic;
using Assets.Scripts.IoC;
using Autofac;
using EntityController.Entity;
using EntityController.Entity.Interfaces;
using Server.SharedThings.Packets.Representations;
using UnityEngine;
using OwnPlayer = Server.SharedThings.Packets.Representations.OwnPlayer;
using Player = Server.SharedThings.Packets.Representations.Player;

namespace EntityController
{
    public class EntitiesController : MonoBehaviour, IEntitiesController
    {
        public OwnPlayerController _ownPlayerController;

        public OtherPlayerController _OtherPlayerController;

        public IDictionary<Guid, IGenericEntityController> Entities { get; set; } = new Dictionary<Guid, IGenericEntityController>();
        
        public IOwnPlayerController OwnPlayerController { get; set; }

        private Transform _tempCanvasTransform;

        private readonly Queue<Player> _entitiesToAdd = new Queue<Player>();
        
        private readonly Queue<OwnPlayer> _ownPlayersToAdd = new Queue<OwnPlayer>();

        private void Update()
        {
            if (_entitiesToAdd.Count > 0 || _ownPlayersToAdd.Count > 0)
            {
                _tempCanvasTransform = GameObject.Find("CanvasWorldSpace").transform;
            }

            AddNewWaitingEntities();
            AddNewWaitingOwnPlayer();
        }

        private void AddNewWaitingEntities()
        {
            if (_entitiesToAdd.Count < 1)
            {
                return;
            }
            
            var player = _entitiesToAdd.Dequeue();
            
            if (Entities.ContainsKey(Guid.Parse(player.Id)))
            {
                return;
            }
            
            var asd = Instantiate(_OtherPlayerController, _tempCanvasTransform);
            asd.Player = new Entity.Player
            {
                Id = Guid.Parse(player.Id),
                Nickname = player.Nickname,
                X = player.X,
                Y = player.Y
            };
            Entities.Add(asd.Player.Id, asd);
        }
        
        private void AddNewWaitingOwnPlayer()
        {
            if (_ownPlayersToAdd.Count < 1)
            {
                if (OwnPlayerController != null)
                {
                    _ownPlayersToAdd.Clear();
                }
                return;
            }
            
            var player = _ownPlayersToAdd.Dequeue();
            
            var asd = Instantiate(_ownPlayerController, _tempCanvasTransform);
            asd.OwnPlayer = new Entity.OwnPlayer
            {
                Nickname = player.Nickname,
                X = player.X,
                Y = player.Y
            };
            OwnPlayerController = asd;
        }

        public void AddNewEntity(Player player)
        {
            _entitiesToAdd.Enqueue(player);
        }

        public void RemoveEntity(Guid guid)
        {
            if (Entities.TryGetValue(guid, out var entity))
            {
                entity.Remove();
            }
            Entities.Remove(guid);
        }

        public void StartOwnPlayer(OwnPlayer player)
        {
            _ownPlayersToAdd.Enqueue(player);
        }
    }
}