using System.Collections.Generic;
using System.Linq;
using Server.SharedThings.Packets.Representations;
using UnityEngine;

namespace UserInterface.GameMenu.CharacterList
{
    public class CharacterListController : ICharacterListController
    {
        private readonly Queue<IEnumerable<Character>> _queue = new Queue<IEnumerable<Character>>();

        private IList<CharacterRepresentationBase> _charactersInCharacterList = new List<CharacterRepresentationBase>();

        private readonly HudController _hudController;

        private GameObject _characterList;

        private bool _destroyList;

        public CharacterListController(HudController hudController)
        {
            _hudController = hudController;
        }
        
        public void Update()
        {
            if (_destroyList && _characterList != null)
            {
                Object.Destroy(_characterList);
                _destroyList = false;
            }
            
            if (_queue?.Count == 0)
            {
                return;
            }

            if (_characterList != null)
            {
                Object.Destroy(_characterList);
            }

            var characterList = Object.Instantiate(_hudController.CharacterListScrollView, GameObject.Find("Canvas").transform);
            
            _characterList = characterList;

            var content = characterList.transform.Find("Viewport").Find("Content");
            
            var characters = _queue.Dequeue();
            
            _charactersInCharacterList = new List<CharacterRepresentationBase>();

            if (characters != null && characters.Any())
            {
                foreach (var character in characters)
                {
                    var characterRepresentation = Object.Instantiate(_hudController.CharacterRepresentationBase, content);
                    characterRepresentation.SetAsPlayableCharacter(character);
                    _charactersInCharacterList.Add(characterRepresentation);
                }
            }
            
            var characterRepresentationCreate = Object.Instantiate(_hudController.CharacterRepresentationBase, content);
            characterRepresentationCreate.SetAsCreateNewCharacter();
        }
        
        public void ShowCharacterList(IEnumerable<Character> characters)
        {
            _queue.Enqueue(characters);
        }

        public void RemoveThisHud()
        {
            _destroyList = true;
        }

        public void ToggleDeleteMode()
        {
            foreach (var characterRepresentation in _charactersInCharacterList)
            {
                characterRepresentation.ToggleDeleteMode();
            }
        }
    }
}