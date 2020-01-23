using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UserInterface.GameInterface;
using Server.SharedThings.Packets.Representations;
using UnityEngine;
using UserInterface.GameInterface;
using UserInterface.GameMenu.CharacterList;
using UserInterface.GameMenu.CreateCharacter;

namespace UserInterface.GameMenu
{
    public class HudController : MonoBehaviour, IHudController
    {
        public static Transform ToPutHudThing => GameObject.Find("Canvas").transform;
        
        public GameObject CharacterListScrollView;
        
        public CharacterRepresentationBase CharacterRepresentationBase;

        public GameObject CharacterCreatorMenu;

        public ChatController Chat;
        
        public ICharacterListController CharacterListController { get; set; }
        
        public ICharacterCreateController CharacterCreateController { get; set; }

        public IChatHandler ChatController { get; set; }
        
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            CharacterListController = new CharacterListController(this);
            CharacterCreateController = new CharacterCreateController(this);
            ChatController = new ChatHandler(this);
        }

        void Update()
        {
            CharacterListController.Update();
            CharacterCreateController.Update();
            ChatController.Update();
        }
    }
}