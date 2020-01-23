using UnityEngine;

namespace UserInterface.GameMenu.CreateCharacter
{
    public class CharacterCreateController : ICharacterCreateController
    {
        private bool _showMenu;
        private bool _destroyMenu;
        private GameObject _actualMenu;
        private readonly HudController _hudController;

        public CharacterCreateController(HudController hudController)
        {
            _hudController = hudController;
        }
        
        public void Update()
        {
            if (_destroyMenu && _actualMenu != null)
            {
                Object.Destroy(_actualMenu);
                _destroyMenu = false;
            }
            
            if (!_showMenu)
            {
                return;
            }

            _showMenu = false;
            
            if (_actualMenu != null)
            {
                Object.Destroy(_actualMenu);
            }

            _actualMenu = Object.Instantiate(_hudController.CharacterCreatorMenu, HudController.ToPutHudThing);
        }

        public void ShowCharacterCreate()
        {
            _showMenu = true;
        }

        public void RemoveThisHud()
        {
            _destroyMenu = true;
        }
    }
}